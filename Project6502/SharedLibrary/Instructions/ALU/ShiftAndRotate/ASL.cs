namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Arithmetic Shift Left</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the result is 1 (bit 6 of the input)</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to the bit shifted out of the input (bit 7)</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class ASL : Instruction
    {
        public override string Name => "ASL";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x0E,
            [RegexPatterns.AbsoluteX] = 0x1E,
            [RegexPatterns.Accumulator] = 0x0A,
            [RegexPatterns.ZP] = 0x06,
            [RegexPatterns.ZPX] = 0x16
        };

        public ASL() { }
        public ASL(byte[] instructionData) => this.instructionData = instructionData;
    }
}