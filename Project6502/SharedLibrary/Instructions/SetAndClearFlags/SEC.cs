namespace SharedLibrary.Instructions.SetAndClearFlags
{
    public class SEC : Instruction
    {
        public override string Name => "SEC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unusedd");
        private const byte opcode = 0x38;

        public SEC() { }
        public SEC(byte[] instructionData) => this.instructionData = instructionData;

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