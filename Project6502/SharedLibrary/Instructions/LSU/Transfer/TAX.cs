namespace SharedLibrary.Instructions.LSU.Transfer
{
    public class TAX : Instruction
    {
        public override string Name => "TAX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new Exception("Unused");
        private const byte opcode = 0xAA;

        public TAX() { }
        public TAX(byte[] instructionData) => this.instructionData = instructionData;

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