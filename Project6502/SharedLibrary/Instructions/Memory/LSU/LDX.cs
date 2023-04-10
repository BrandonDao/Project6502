namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Index Register X From Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of Register X after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if Register X is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDX : Instruction
    {
        public override string Name => "LDX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAE,
            [RegexPatterns.AbsoluteY] = 0xBE,
            [RegexPatterns.Immediate] = 0xA2,
            [RegexPatterns.ZP] = 0xA6,
            [RegexPatterns.ZPY] = 0xB6
        };

        public LDX() { }
        public LDX(byte[] instructionData) => this.instructionData = instructionData;
    }
}