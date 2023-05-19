using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"OR" Memory with Accumulator</para>
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
    public class ORA : Instruction
    {
        public override string Name => "ORA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x0D, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x1D, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0x19, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0x09, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x05, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x15, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0x01, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0x11, ZeroPageIndirectY.Instance),
        };

        public ORA() { }
        public ORA(byte[] instructionData) => this.instructionData = instructionData;
    }
}