namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Clear Decimal Mode</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>D (Decimal Mode)</term>
    ///         <description>Set to 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CLD : Instruction
    {
        public override string Name => "CLD";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xD8;

        public CLD() { }
        public CLD(byte[] instructionData) => this.instructionData = instructionData;

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