namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Zero</para>
    /// </summary>
    public class BEQ : Instruction
    {
        public override string Name => "BEQ";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xF0;

        public BEQ() { }
        public BEQ(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode, (byte)(LabelToLineNum[asmInstruction.Trim()] - lineNumber) };
        }
    }
}