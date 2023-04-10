namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Increment Memory By One</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the difference is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the increment is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class INC : Instruction
    {
        public override string Name => "INC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xEE,
            [RegexPatterns.AbsoluteX] = 0xFE,
            [RegexPatterns.ZP] = 0xE6,
            [RegexPatterns.ZPX] = 0xF6
        };

        public INC() { }
        public INC(byte[] instructionData) => this.instructionData = instructionData;
    }
}