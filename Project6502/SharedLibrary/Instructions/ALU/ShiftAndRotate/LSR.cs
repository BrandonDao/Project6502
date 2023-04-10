namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Logical Shift Right</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the result is 1 (will always be 0)</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to the bit shifted out of the input (bit 0)</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LSR : Instruction
    {
        public override string Name => "LSR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4E,
            [RegexPatterns.AbsoluteX] = 0x5E,
            [RegexPatterns.Accumulator] = 0x4A,
            [RegexPatterns.ZP] = 0x46,
            [RegexPatterns.ZPX] = 0x56
        };

        public LSR() { }
        public LSR(byte[] instructionData) => this.instructionData = instructionData;
    }
}