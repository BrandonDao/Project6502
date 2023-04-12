namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Minus</para>
    /// </summary>
    public class BMI : Instruction
    {
        public override string Name => "BMI";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x30;

        public BMI() { }
        public BMI(byte[] instructionData) => this.instructionData = instructionData;

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