namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Clear Carry Flag</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CLC : Instruction
    {
        public override string Name => "CLC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x18;

        public CLC() { }
        public CLC(byte[] instructionData) => this.instructionData = instructionData;

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