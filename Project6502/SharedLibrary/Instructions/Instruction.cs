using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public abstract string Name { get; }
        public abstract Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo { get; }
        public byte[] InstructionData { get; set; }


        private const string labelPattern = @"^ *([a-z]+):";
        private static Dictionary<string, Instruction> instructionByNamePattern;
        private static Dictionary<byte, InstructionInfo> instructionInfoByOpCode;
        private static Dictionary<string, short> labelToPosition;
        private static short machineCodeLength;

        public abstract void Execute(byte opCode, byte[] instructionData, byte[] memory, CPU CPU);

        
        
        public static List<Instruction> Parse(string[] asmInstructions, ushort memoryStartAddress)
            => ParseIL(ParseAssembly(asmInstructions, memoryStartAddress));

        public static byte[] ToByteArray(List<Instruction> instructions)
        {
            var machineCode = new byte[machineCodeLength];
            int index = 0;

            foreach (var instruction in instructions)
            {
                foreach (byte b in instruction.InstructionData)
                {
                    machineCode[index] = b;
                    index++;
                }
            }

            return machineCode;
        }



        private static void SetupMaps(out Instruction[] validInstructions)
        {
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

            instructionInfoByOpCode = new Dictionary<byte, InstructionInfo>();
            foreach (Instruction instruction in validInstructions)
            {
                foreach (var info in instruction.AddressingModeToInfo.Values)
                {
                    if (info.AddressingMode == AbsoluteLabeled.Instance || info.AddressingMode == RelativeLabeled.Instance) continue;

                    info.InstructionType = instruction.GetType();
                    instructionInfoByOpCode.Add(info.OpCode, info);
                }
            }
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
        private static void ConvertLineToIL(ref string line, byte opCode)
            => line = opCode.ToString("X2") + line.Substring(3);

        private static List<string> ParseAssembly(string[] assemblyInstructions, ushort memoryStartAddress)
        {
            SetupMaps(out Instruction[] allInstructions);

            List<string> ILInstructions = new();
            ushort position = memoryStartAddress;

            for (int lineNum = 0; lineNum < assemblyInstructions.Length; lineNum++)
            {
                string line = assemblyInstructions[lineNum];
                FormatLine(ref line);

                var labelMatch = Regex.Match(line, labelPattern, RegexOptions.IgnoreCase);
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
                    string address = line.Substring(3);

                    foreach (IAddressingMode addressingMode in instruction.AddressingModeToInfo.Keys)
                    {
                        var addressingModeMatch = Regex.Match(address, addressingMode.Pattern, RegexOptions.IgnoreCase);
                        if (!addressingModeMatch.Success)
                        {
                            continue;
                        }

                        ConvertLineToIL(ref line, instruction.AddressingModeToInfo[addressingMode].OpCode);

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
                byte opCode;
                string address;

                if (instruction.Length == 2)
                {
                    opCode = byte.Parse(instruction, NumberStyles.AllowHexSpecifier);
                    address = "";
                }
                else
                {
                    opCode = byte.Parse(instruction[..2], NumberStyles.AllowHexSpecifier);
                    address = instruction[3..].TrimStart();
                }
                

                IAddressingMode addressingMode = instructionInfoByOpCode[opCode].AddressingMode;

                if(address.Length != 0 && Regex.Match(address[0].ToString(), @"[\(\$#]").Success == false)
                {
                    if (addressingMode == Absolute.Instance)
                    {
                        string temp = labelToPosition[address].ToString("X4");
                        address = '$' + temp[2..] + temp[..2];
                    }
                    else if (addressingMode == Relative.Instance)
                    {
                        address = ((byte)(labelToPosition[address] - machineCodeLength - addressingMode.InstructionLength)).ToString("X2");
                    }
                }
                

                byte[] machineCode = addressingMode.Parse(opCode, address);
                machineCodeLength += (short)machineCode.Length;

                Type type = instructionInfoByOpCode[opCode].InstructionType;
                parsedInstructions.Add((Instruction)Activator.CreateInstance(type, machineCode));
            }


            return parsedInstructions;
        }
    }
}