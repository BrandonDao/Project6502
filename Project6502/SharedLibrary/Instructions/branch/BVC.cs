namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Overflow Clear</para>
    /// </summary>
    public class BVC : Instruction
    {
        public override string Name => "BVC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x50;

        public BVC() { }
        public BVC(byte[] instructionData) => this.instructionData = instructionData;

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