namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Clear Interrupt Disable</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>I (Interrupt Disable)</term>
    ///         <description>Set to 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CLI : Instruction
    {
        public override string Name => "CLI";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x58;

        public CLI() { }
        public CLI(byte[] instructionData) => this.instructionData = instructionData;

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
