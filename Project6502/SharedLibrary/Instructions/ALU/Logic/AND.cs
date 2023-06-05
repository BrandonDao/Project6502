using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"AND" Memory with Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the result is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class AND : Instruction
    {
        public override string Name => "AND";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x2D, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x3D, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0x39, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0x29, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x25, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x35, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0x21, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0x31, ZeroPageIndirectY.Instance),
        };

        public AND() { }
        public AND(byte[] instructionData) => this.instructionData = instructionData;
    }
}