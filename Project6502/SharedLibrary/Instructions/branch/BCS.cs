namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Carry Set</para>
    /// </summary>
    public class BCS : Instruction
    {
        public override string Name => "BCS";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xB0;

        public BCS() { }
        public BCS(byte[] instructionData) => this.instructionData = instructionData;

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