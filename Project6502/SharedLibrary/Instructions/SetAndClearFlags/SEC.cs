using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Set Carry Flag</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SEC : Instruction
    {
        public override string Name => "SEC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x38, Implied.Instance)
        };

        public SEC() { }
        public SEC(byte[] instructionData) => this.instructionData = instructionData;
    }
}