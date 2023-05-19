using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Set Decimal Mode</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>D (Decimal Mode)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SED : Instruction
    {
        public override string Name => "SED";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xF8, Implied.Instance)
        };

        public SED() { }
        public SED(byte[] instructionData) => this.instructionData = instructionData;
    }
}