namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Clear Overflow Flag</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>V (Overflow)</term>
    ///         <description>Set to 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CLV : Instruction
    {
        public override string Name => "CLV";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xB8;

        public CLV() { }
        public CLV(byte[] instructionData) => this.instructionData = instructionData;

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