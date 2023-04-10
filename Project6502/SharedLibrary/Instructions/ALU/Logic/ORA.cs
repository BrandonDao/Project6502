namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"OR" Memory with Accumulator</para>
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
    public class ORA : Instruction
    {
        public override string Name => "ORA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x0D,
            [RegexPatterns.AbsoluteX] = 0x1D,
            [RegexPatterns.AbsoluteY] = 0x19,
            [RegexPatterns.Immediate] = 0x09,
            [RegexPatterns.ZP] = 0x05,
            [RegexPatterns.ZPX] = 0x15,
            [RegexPatterns.ZPXIndirect] = 0x01,
            [RegexPatterns.ZPIndirectY] = 0x11,
        };

        public ORA() { }
        public ORA(byte[] instructionData) => this.instructionData = instructionData;
    }
}