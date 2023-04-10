namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Rotate Left</para>
    /// <para>Shifts right 1 bit with bit 0 stored in the carry and the carry stored in bit 7</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set to the input carry</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to bit 0 of the input</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class ROR : Instruction
    {
        public override string Name => "ROR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x6E,
            [RegexPatterns.AbsoluteX] = 0x7E,
            [RegexPatterns.Accumulator] = 0x6A,
            [RegexPatterns.ZP] = 0x66,
            [RegexPatterns.ZPX] = 0x76
        };

        public ROR() { }
        public ROR(byte[] instructionData) => this.instructionData = instructionData;
    }
}