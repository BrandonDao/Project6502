namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Index Register Y From Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of Register Y after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if Register Y is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDY : Instruction
    {
        public override string Name => "LDY";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAC,
            [RegexPatterns.AbsoluteY] = 0xBC,
            [RegexPatterns.Immediate] = 0xA0,
            [RegexPatterns.ZP] = 0xA4,
            [RegexPatterns.ZPY] = 0xB4
        };

        public LDY() { }
        public LDY(byte[] instructionData) => this.instructionData = instructionData;
    }
}