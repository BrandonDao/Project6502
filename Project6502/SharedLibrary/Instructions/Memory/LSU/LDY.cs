using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Index Register Y From Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of Register Y after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if Register Y is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDY : Instruction
    {
        public override string Name => "LDY";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xAC, Absolute.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0xBC, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0xA0, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xA4, ZeroPage.Instance),
            [ZeroPageY.Instance] = new InstructionInfo(0xB4, ZeroPageY.Instance)
        };

        public LDY() { }
        public LDY(byte[] instructionData) => this.instructionData = instructionData;
    }
}