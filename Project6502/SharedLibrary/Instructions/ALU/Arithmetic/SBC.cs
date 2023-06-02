using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

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
        public override string Name => "SBC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xED, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0xFD, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0xF9, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0xE9, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xE5, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0xEF, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0xE1, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0xF1, ZeroPageIndirectY.Instance)
        };

        public SBC() { }
        public SBC(byte[] instructionData) => this.instructionData = instructionData;
    }
}