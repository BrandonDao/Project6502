namespace SharedLibrary.Instructions.Memory.Stack
{
    /// <summary>
    /// <para>Pull Processor Status From Stack</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>V (Overflow)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Break)</term>
    ///         <description>NOT Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>D (Decimal Mode)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>I (Interrupt Disable)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Updated</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class PLP : Instruction
    {
        public override string Name => "PLP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x28;

        public PLP() { }
        public PLP(byte[] instructionData) => this.instructionData = instructionData;

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