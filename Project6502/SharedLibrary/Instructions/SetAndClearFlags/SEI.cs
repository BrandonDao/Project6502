namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Set Interrupt Disable</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>I (Interrupt Disable)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SEI : Instruction
    {
        public override string Name => "SEI";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x78;

        public SEI() { }
        public SEI(byte[] instructionData) => this.instructionData = instructionData;

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