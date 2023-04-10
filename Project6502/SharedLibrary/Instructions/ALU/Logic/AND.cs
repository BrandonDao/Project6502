namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"AND" Memory with Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the result is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class AND : Instruction
    {
        public override string Name => "AND";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x2D,
            [RegexPatterns.AbsoluteX] = 0x3D,
            [RegexPatterns.AbsoluteY] = 0x39,
            [RegexPatterns.Immediate] = 0x29,
            [RegexPatterns.ZP] = 0x25,
            [RegexPatterns.ZPX] = 0x35,
            [RegexPatterns.ZPXIndirect] = 0x21,
            [RegexPatterns.ZPIndirectY] = 0x31,
        };

        public AND() { }
        public AND(byte[] instructionData) => this.instructionData = instructionData;
    }
}