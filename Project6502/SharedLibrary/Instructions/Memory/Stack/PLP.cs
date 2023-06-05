using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.Memory.Stack
{
    /// <summary>
    /// <para>Pull Processor Status From Stack</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>V (Overflow)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Break)</term>
    ///         <description>NOT Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>D (Decimal Mode)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>I (Interrupt Disable)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Updated</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Updated</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class PLP : Instruction
    {
        public override string Name => "PLP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x28, Implied.Instance)
        };

        public PLP() { }
        public PLP(byte[] instructionData) => this.instructionData = instructionData;
    }
}