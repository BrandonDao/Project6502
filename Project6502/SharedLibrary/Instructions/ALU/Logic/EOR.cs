using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.Logic
{
    /// <summary>
    /// <para>"Exclusive OR" Memory with Accumulator</para>
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
    public class EOR : Instruction
    {
        public override string Name => "EOR";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x4D, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x5D, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0x59, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0x49, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x45, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x55, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0x41, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0x51, ZeroPageIndirectY.Instance),
        };

        public EOR() { }
        public EOR(byte[] instructionData) => this.instructionData = instructionData;
    }
}