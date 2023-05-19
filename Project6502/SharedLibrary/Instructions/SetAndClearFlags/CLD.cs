using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Clear Decimal Mode</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>D (Decimal Mode)</term>
    ///         <description>Set to 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CLD : Instruction
    {
        public override string Name => "CLD";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xD8, Implied.Instance)
        };

        public CLD() { }
        public CLD(byte[] instructionData) => this.instructionData = instructionData;
    }
}