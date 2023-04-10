namespace SharedLibrary.Instructions.ALU.Arithmetic
{
    /// <summary>
    /// <para>Subtract Memory from Accumulator with Borrow</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>V (Overflow)</term>
    ///         <description>Set if bit 7 changes from exceeding +127 or -128</description>
    ///     </item>
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if result is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set if a borrow is needed; result is less than 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <remarks>Note: On the MOS 6502, the N, V, and Z flags in decimal mode don't match the result</remarks>
    public class SBC : Instruction
    {
        public override string Name => "ADC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xED,
            [RegexPatterns.AbsoluteX] = 0xFD,
            [RegexPatterns.AbsoluteY] = 0xF9,
            [RegexPatterns.Immediate] = 0xE9,
            [RegexPatterns.ZP] = 0xE5,
            [RegexPatterns.ZPX] = 0xEF,
            [RegexPatterns.ZPXIndirect] = 0xE1,
            [RegexPatterns.ZPIndirectY] = 0xF1
        };

        public SBC() { }
        public SBC(byte[] instructionData) => this.instructionData = instructionData;
    }
}