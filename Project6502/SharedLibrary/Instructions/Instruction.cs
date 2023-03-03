using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
#pragma warning disable // Null-related warnings disabled types are guaranteed to be non-null by runtime

        public static Dictionary<byte, byte> OpcodeToInstructionLength = new();

        public abstract string Name { get; }
        public abstract Dictionary<string, byte> AddressingPatternToOpcode { get; }

        public byte Opcode => instructionData[0];
        protected byte[] instructionData;


        private static Instruction[] GetAllInstructions()
            => Assembly.GetAssembly(typeof(Instruction))
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Instruction)))
                .Select(type => (Instruction)Activator.CreateInstance(type))
                .ToArray();

#pragma warning enable

        protected virtual byte[] GetInstructionData(string asmInstruction, Instruction instruction)
        {
            foreach (var regexPattern in instruction.AddressingPatternToOpcode.Keys)
            {
                var match = Regex.Match(asmInstruction, regexPattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    short address = short.Parse(match.Groups[1].Value, NumberStyles.AllowHexSpecifier);
                    byte opcode = instruction.AddressingPatternToOpcode[regexPattern];

                    byte msb = (byte)((address & 0xFF00) >> 8);
                    byte lsb = (byte)((address & 0x00FF));

                    byte[] data = msb > 0 ? new byte[] { opcode, lsb, msb } : new byte[] { opcode, lsb };

                    if (!OpcodeToInstructionLength.ContainsKey(opcode))
                    {
                        OpcodeToInstructionLength.Add(opcode, (byte)data.Length);
                    }

                    return data;
                }
            }
            throw new ArgumentException("Invalid assembly syntax!", paramName: asmInstruction);
        }

        public static List<Instruction> Parse(string[] asmInstructions)
        {
            List<Instruction> parsedInstructions = new(asmInstructions.Length);
            var allInstructions = GetAllInstructions();

            foreach (string asmInstruction in asmInstructions)
            {
                if (asmInstruction.Equals("\r")) continue;

                string instructionName = asmInstruction[..3];

                foreach (Instruction instruction in allInstructions)
                {
                    if (!instruction.Name.Equals(instructionName)) continue;

                    byte[] data = instruction.GetInstructionData(asmInstruction[4..], instruction);
                    parsedInstructions.Add((Instruction)Activator.CreateInstance(instruction.GetType(), data));
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

            foreach(var instruction in instructions)
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