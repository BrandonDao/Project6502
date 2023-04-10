namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Accumulator with Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of the accumulator after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the accumulator is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDA : Instruction
    {
        public override string Name => "LDA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAD,
            [RegexPatterns.AbsoluteX] = 0xBD,
            [RegexPatterns.AbsoluteY] = 0xB9,
            [RegexPatterns.Immediate] = 0xA9,
            [RegexPatterns.ZP] = 0xA5,
            [RegexPatterns.ZPX] = 0xB5,
            [RegexPatterns.ZPXIndirect] = 0xA1,
            [RegexPatterns.ZPIndirectY] = 0xB1
        };

        public LDA() { }
        public LDA(byte[] instructionData) => this.instructionData = instructionData;
    }
}