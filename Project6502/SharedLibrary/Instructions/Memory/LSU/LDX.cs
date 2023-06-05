using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Index Register X From Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of Register X after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if Register X is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDX : Instruction
    {
        public override string Name => "LDX";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xAE, Absolute.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0xBE, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0xA2, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xA6, ZeroPage.Instance),
            [ZeroPageY.Instance] = new InstructionInfo(0xB6, ZeroPageY.Instance)
        };

        public LDX() { }
        public LDX(byte[] instructionData) => this.instructionData = instructionData;
    }
}