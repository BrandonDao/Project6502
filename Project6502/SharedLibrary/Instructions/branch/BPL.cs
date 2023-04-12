namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Plus</para>
    /// </summary>
    public class BPL : Instruction
    {
        public override string Name => "BPL";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x10;

        public BPL() { }
        public BPL(byte[] instructionData) => this.instructionData = instructionData;

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