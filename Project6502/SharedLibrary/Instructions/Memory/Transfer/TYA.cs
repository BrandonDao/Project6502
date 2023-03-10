namespace SharedLibrary.Instructions.LSU.Transfer
{
    public class TYA : Instruction
    {
        public override string Name => "TYA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x98;

        public TYA() { }
        public TYA(byte[] instructionData) => this.instructionData = instructionData;

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