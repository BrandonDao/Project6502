namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Overflow Set</para>
    /// </summary>
    public class BVS : Instruction
    {
        public override string Name => "BVS";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x70;

        public BVS() { }
        public BVS(byte[] instructionData) => this.instructionData = instructionData;

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