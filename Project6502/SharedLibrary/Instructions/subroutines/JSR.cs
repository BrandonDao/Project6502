namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump To Subroutine</para>
    /// </summary>
    public class JSR : Instruction
    {
        public override string Name => "JSR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x20;

        public JSR() { }
        public JSR(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode };
        }
    }
}