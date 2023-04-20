using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Return From Interrupt</para>
    /// <para>Restores Program Counter and Flags to pre-interrupt status:</para>
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
    public class RTI : Instruction
    {
        public override string Name => "RTI";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x40, Implied.Instance)
        };

        public RTI() { }
        public RTI(byte[] instructionData) => this.instructionData = instructionData;
    }
}