namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    /// <summary>
    /// <para>Compare Memory and Accumulator</para>
    /// <para>Subtracts contents of Memory from contents of Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the difference is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set if contents of memory >= contents of accumulator</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CMP : Instruction
    {
        public override string Name => "CMP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xCD,
            [RegexPatterns.AbsoluteX] = 0xDD,
            [RegexPatterns.AbsoluteY] = 0xD9,
            [RegexPatterns.Immediate] = 0xC9,
            [RegexPatterns.ZP] = 0xC5,
            [RegexPatterns.ZPX] = 0xD5,
            [RegexPatterns.ZPXIndirect] = 0xC1,
            [RegexPatterns.ZPIndirectY] = 0xD1
        };

        public CMP() { }
        public CMP(byte[] instructionData) => this.instructionData = instructionData;
    }
}