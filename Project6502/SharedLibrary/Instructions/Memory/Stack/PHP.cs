namespace SharedLibrary.Instructions.Stack
{
    /// <summary>
    /// <para>Push Processor Status On Stack</para>
    /// </summary>
    public class PHP : Instruction
    {
        public override string Name => "PHP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x08;

        public PHP() { }
        public PHP(byte[] instructionData) => this.instructionData = instructionData;

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