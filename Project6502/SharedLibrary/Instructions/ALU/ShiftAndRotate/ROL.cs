namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Rotate Left</para>
    /// <para>Shifts left 1 bit with the carry being stored in bit 0 and input bit 7 in the carry</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set to bit 6 of the input</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to bit 7 of the input</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class ROL : Instruction
    {
        public override string Name => "ROL";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x2E,
            [RegexPatterns.AbsoluteX] = 0x3E,
            [RegexPatterns.Accumulator] = 0x2A,
            [RegexPatterns.ZP] = 0x26,
            [RegexPatterns.ZPX] = 0x36
        };

        public ROL() { }
        public ROL(byte[] instructionData) => this.instructionData = instructionData;
    }
}