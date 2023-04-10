namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"Exclusive OR" Memory with Accumulator</para>
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
    public class EOR : Instruction
    {
        public override string Name => "EOR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4D,
            [RegexPatterns.AbsoluteX] = 0x5D,
            [RegexPatterns.AbsoluteY] = 0x59,
            [RegexPatterns.Immediate] = 0x49,
            [RegexPatterns.ZP] = 0x45,
            [RegexPatterns.ZPX] = 0x55,
            [RegexPatterns.ZPXIndirect] = 0x41,
            [RegexPatterns.ZPIndirectY] = 0x51,
        };

        public EOR() { }
        public EOR(byte[] instructionData) => this.instructionData = instructionData;
    }
}