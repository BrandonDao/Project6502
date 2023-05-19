using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public abstract string Name { get; }
        public abstract Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo { get; }

        protected byte[] instructionData;


        private const string labelPattern = @"^ *([a-z]+):";
        private static Dictionary<string, Instruction> instructionByNamePattern;
        private static Dictionary<byte, InstructionInfo> instructionInfoByOpcode;
        private static Dictionary<string, short> labelToPosition;
        private static short machineCodeLength;


        public static List<Instruction> Parse(string[] asmInstructions)
            => ParseIL(ParseAssembly(asmInstructions));

        public static byte[] ToByteArray(List<Instruction> instructions)
        {
            var machineCode = new byte[machineCodeLength];
            int index = 0;

            foreach (var instruction in instructions)
            {
                foreach (byte b in instruction.instructionData)
                {
                    machineCode[index] = b;
                    index++;
                }
            }

            return machineCode;
        }
        

        
        private static void SetupMaps(out Instruction[] validInstructions)
        {
#pragma warning disable // possible null reference
            var allInstructions = Assembly
                .GetAssembly(typeof(Instruction))
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Instruction)));

            var instantiatedInstructions = allInstructions
                .Where(type => type.GetConstructors().Length == 2)
                .Select(type => (Instruction)Activator.CreateInstance(type))
                .ToArray();

            if (instantiatedInstructions.Length != allInstructions.Count())
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

            validInstructions = instantiatedInstructions;
            instructionByNamePattern = validInstructions.ToDictionary(type => ("^" + type.Name + @"( |\Z)"), type => type);

            labelToPosition = new Dictionary<string, short>();

            instructionInfoByOpcode = new Dictionary<byte, InstructionInfo>();
            foreach (Instruction instruction in validInstructions)
            {
                foreach (var info in instruction.AddressingModeToInfo.Values)
                {
                    if (info.AddressingMode == AbsoluteLabeled.Instance) continue;

                    info.InstructionType = instruction.GetType();
                    instructionInfoByOpcode.Add(info.Opcode, info);
                }
            }

#pragma warning enable
        }

        private static void FormatLine(ref string line)
        {
            int commentIndex = line.IndexOf(';');
            if (commentIndex != -1)
            {
                line = line.Substring(0, commentIndex);
            }

            line = line.Trim();
        }
        private static void ConvertLineToIL(ref string line, byte opcode)
            => line = opcode.ToString("X2") + line.Substring(3);

        private static List<string> ParseAssembly(string[] assemblyInstructions)
        {
            SetupMaps(out Instruction[] allInstructions);

            List<string> ILInstructions = new();
            short position = 0x00;

            for (int lineNum = 0; lineNum < assemblyInstructions.Length; lineNum++)
            {
                string line = assemblyInstructions[lineNum];
                FormatLine(ref line);

                var labelMatch = Regex.Match(line, labelPattern);
                if (labelMatch.Success)
                {
                    labelToPosition.Add(labelMatch.Groups[1].Value, (short)(position));
                    continue;
                }

                foreach (string namePattern in instructionByNamePattern.Keys)
                {
                    var nameMatch = Regex.Match(line, namePattern, RegexOptions.IgnoreCase);
                    if (!nameMatch.Success)
                    {
                        continue;
                    }

                    var instruction = (Instruction)Activator.CreateInstance(instructionByNamePattern[namePattern].GetType());

                    foreach (IAddressingMode addressingMode in instruction.AddressingModeToInfo.Keys)
                    {
                        string address = line.Substring(3);

                        var addressingModeMatch = Regex.Match(address, addressingMode.Pattern, RegexOptions.IgnoreCase);
                        if (!addressingModeMatch.Success)
                        {
                            continue;
                        }

                        ConvertLineToIL(ref line, instruction.AddressingModeToInfo[addressingMode].Opcode);

                        position += addressingMode.InstructionLength;
                        ILInstructions.Add(line);
                        break;
                    }
                    break;
                }
            }

            return ILInstructions;
        }
        
        private static List<Instruction> ParseIL(List<string> ILInstructions)
        {
            var parsedInstructions = new List<Instruction>(ILInstructions.Count);

            foreach (string instruction in ILInstructions)
            {
                byte opcode;
                string address;

                if (instruction.Length == 2)
                {
                    opcode = byte.Parse(instruction, NumberStyles.AllowHexSpecifier);
                    address = "";
                }
                else
                {
                    opcode = byte.Parse(instruction[..2], NumberStyles.AllowHexSpecifier);

                    address = instruction[3..].TrimStart();

                    if (Regex.Match(address[0].ToString(), @"[\(\$#]").Success == false)
                    {
                        string temp = labelToPosition[address].ToString("X4");
                        address = temp[2..] + temp[..2];
                    }
                }               

                IAddressingMode addressingMode = instructionInfoByOpcode[opcode].AddressingMode;
                byte[] machineCode = addressingMode.Parse(opcode, address);
                machineCodeLength += (short)machineCode.Length;

                Type type = instructionInfoByOpcode[opcode].InstructionType;
                parsedInstructions.Add((Instruction)Activator.CreateInstance(type, machineCode));
            }


            return parsedInstructions;
        }
    }
}