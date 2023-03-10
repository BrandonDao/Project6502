namespace SharedLibrary.Instructions.LSU.Transfer
{
    public class TAY : Instruction
    {
        public override string Name => "TAY";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xA8;

        public TAY() { }
        public TAY(byte[] instructionData) => this.instructionData = instructionData;

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