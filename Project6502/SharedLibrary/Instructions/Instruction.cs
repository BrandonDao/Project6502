using SharedLibrary.AddressingModes;
using System.Reflection;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public abstract string Name { get; }
        public abstract Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo { get; }

        protected byte[] instructionData;


        private static Dictionary<string, short> labelToPosition;
        private static short machineCodeLength;


        public static List<Instruction> Parse(string[] asmInstructions)
            => ParseIL(ParseAssembly(asmInstructions));

        private static Instruction[] GetAllInstructions()
        {
#pragma warning disable // possible null reference
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
#pragma warning enable
        }
        
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

        private static string[] ParseAssembly(string[] assemblyInstructions)
        {
            throw new NotImplementedException();
        }

        private static List<Instruction> ParseIL(string[] ILInstructions)
        {
            throw new NotImplementedException();
        }
    }
}