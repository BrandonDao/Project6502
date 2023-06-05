using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

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

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x6D, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x7D, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0x79, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0x69, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x65, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x75, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0x61, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0x71, ZeroPageIndirectY.Instance)
        };

        public ADC() { }
        public ADC(byte[] instructionData) => this.instructionData = instructionData;
    }
}