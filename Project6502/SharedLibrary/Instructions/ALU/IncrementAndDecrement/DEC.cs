namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Decrement Memory By One</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the difference is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the decrement is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class DEC : Instruction
    {
        public override string Name => "DEC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xCE,
            [RegexPatterns.AbsoluteX] = 0xDE,
            [RegexPatterns.ZP] = 0xC6,
            [RegexPatterns.ZPX] = 0xD6
        };

        public DEC() { }
        public DEC(byte[] instructionData) => this.instructionData = instructionData;
    }
}