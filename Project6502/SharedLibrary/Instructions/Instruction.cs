using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public static Dictionary<string, short> LabelToLineNum = new();
        public static Dictionary<byte, byte> OpcodeToInstructionLength = new();

#pragma warning disable // Potentially null variables are actually guaranteed to be not-null by runtime
        public abstract string Name { get; }
        public abstract Dictionary<string, byte> AddressingPatternToOpcode { get; }
        public byte Opcode => instructionData[0];

        protected byte[] instructionData;

        private static Instruction[] GetAllInstructions()
        {
            var allInstructions = Assembly
                .GetAssembly(typeof(Instruction))
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Instruction)));

            var output = allInstructions
                .Where(type => type.GetConstructors().Length == 2)
                .Select(type => (Instruction)Activator.CreateInstance(type))
                .ToArray();

            if (output.Length != allInstructions.Count())
            {
                string invalidInstructions = "";

                allInstructions
                    .Where(type => type.GetConstructors().Length != 2)
                    .Select(type => (Instruction)Activator.CreateInstance(type))
                    .ToList()
                    .ForEach((instruction) => { invalidInstructions += instruction.Name + " + "; });

                invalidInstructions = invalidInstructions.Substring(0, invalidInstructions.Length - 3);

                throw new NotImplementedException($"{invalidInstructions} do not contain valid constructors");
            }

            return output;
        }
        private static void IndexLabels(string[] asmInstructions)
        {
            short lineNum = 0x0600;

            foreach (string line in asmInstructions)
            {
                if (Regex.Match(line, RegexPatterns.Empty).Success)
                {
                    continue;
                }

                var match = Regex.Match(line, RegexPatterns.Label);

                if (!match.Success)
                {
                    lineNum++;
                    continue;
                }
                LabelToLineNum.Add(match.Groups[1].Value, lineNum);
            }
        }
#pragma warning enable

        protected virtual byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            foreach (var regexPattern in instruction.AddressingPatternToOpcode.Keys)
            {
                var match = Regex.Match(asmInstruction, regexPattern, RegexOptions.IgnoreCase);

                if (!match.Success) continue;

                byte[] data;
                byte opcode = instruction.AddressingPatternToOpcode[regexPattern];
                short address = short.Parse(match.Groups[1].Value, NumberStyles.AllowHexSpecifier);

                if (regexPattern.Equals(RegexPatterns.Accumulator))
                {
                    data = new byte[] { opcode };
                }
                else
                {
                    byte msb = (byte)((address & 0xFF00) >> 8);
                    byte lsb = (byte)((address & 0x00FF));

                    data = msb != 0
                        ? new byte[] { opcode, lsb, msb }
                        : new byte[] { opcode, lsb };
                }

                if (!OpcodeToInstructionLength.ContainsKey(opcode))
                {
                    OpcodeToInstructionLength.Add(opcode, (byte)data.Length);
                }

                return data;
            }
            throw new ArgumentException("Invalid assembly syntax!", paramName: asmInstruction);
        }

        public static List<Instruction> Parse(string[] asmInstructions)
        {
            // Preprocessing
            IndexLabels(asmInstructions);

            List<Instruction> parsedInstructions = new(asmInstructions.Length);
            var allInstructions = GetAllInstructions();

            short lineNum = 0x0600;
            foreach (string asmInstruction in asmInstructions)
            {
                var trimmedAsmInstruction = asmInstruction.TrimStart();
                if (trimmedAsmInstruction.Equals("")) continue;

                string instructionName = trimmedAsmInstruction[..3].ToUpper();

                foreach (Instruction instruction in allInstructions)
                {
                    if (!instruction.Name.Equals(instructionName)) continue;

                    byte[] data = instruction.GetInstructionData(lineNum, trimmedAsmInstruction[3..], instruction);
                    parsedInstructions.Add((Instruction)Activator.CreateInstance(instruction.GetType(), data));
                    lineNum++;
                }
            }

            return parsedInstructions;
        }

        public static byte[] ToByteArray(List<Instruction> instructions)
        {
            // Time O(2n)

            int length = 0;

            foreach (var instruction in instructions)
            {
                length += instruction.instructionData.Length;
            }

            var bytecode = new byte[length];
            int index = 0;

            foreach (var instruction in instructions)
            {
                foreach (byte b in instruction.instructionData)
                {
                    bytecode[index] = b;
                    index++;
                }
            }

            return bytecode;
        }
    }
}