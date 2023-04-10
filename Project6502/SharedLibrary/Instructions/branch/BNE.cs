namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Not Zero</para>
    /// </summary>
    public class BNE : Instruction
    {
        public override string Name => "BNE";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xD0;

        public BNE() { }
        public BNE(byte[] instructionData) => this.instructionData = instructionData;

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