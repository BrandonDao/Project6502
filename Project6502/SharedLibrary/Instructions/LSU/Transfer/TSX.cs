using System.Reflection.Emit;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    public class TSX : Instruction
    {
        public override string Name => "TSX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new Exception("Unused");
        private const byte opcode = 0xBA;

        public TSX() { }
        public TSX(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode };
        }
    }
}