using SharedLibrary.Instructions.ALU.CompareAndTestBit;
using System.Collections.Generic;

namespace SharedLibrary.Instructions.ALU.Arithmetic
{
    /// <summary>
    /// <para>Add value in Memory to value in Accumulator with Carry</para>
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
    ///         <description>Set if binary add exceeds 255 or decimal add exceeds 99</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class ADC : Instruction
    {
        public override string Name => "ADC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x6D,
            [RegexPatterns.AbsoluteX] = 0x7D,
            [RegexPatterns.AbsoluteY] = 0x79,
            [RegexPatterns.Immediate] = 0x69,
            [RegexPatterns.ZP] = 0x65,
            [RegexPatterns.ZPX] = 0x75,
            [RegexPatterns.ZPXIndirect] = 0x61,
            [RegexPatterns.ZPIndirectY] = 0x71
        };

        public ADC() { }
        public ADC(byte[] instructionData) => this.instructionData = instructionData;
    }
}