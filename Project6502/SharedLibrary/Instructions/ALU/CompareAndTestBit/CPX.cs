namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    /// <summary>
    /// <para>Compare Index Register X To Memory</para>
    /// <para>Subtracts contents of Memory from contents of Register X</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the difference is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the difference is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set if absolute value of register X >= contents of memory</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CPX : Instruction
    {
        public override string Name => "CPX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xEC,
            [RegexPatterns.Immediate] = 0xE0,
            [RegexPatterns.ZP] = 0xE4
        };

        public CPX() { }
        public CPX(byte[] instructionData) => this.instructionData = instructionData;
    }
}