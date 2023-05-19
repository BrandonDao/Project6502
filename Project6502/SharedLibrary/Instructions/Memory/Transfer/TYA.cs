using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Index Y To Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the accumulator after the transfer is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the accumulator is 0 after the transfer</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class TYA : Instruction
    {
        public override string Name => "TYA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x98, Implied.Instance)
        };

        public TYA() { }
        public TYA(byte[] instructionData) => this.instructionData = instructionData;
    }
}