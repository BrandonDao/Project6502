using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Set Interrupt Disable</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>I (Interrupt Disable)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SEI : Instruction
    {
        public override string Name => "SEI";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x78, Implied.Instance)
        };

        public SEI() { }
        public SEI(byte[] instructionData) => this.instructionData = instructionData;
    }
}