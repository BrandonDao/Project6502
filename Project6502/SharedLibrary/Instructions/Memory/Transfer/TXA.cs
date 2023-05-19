using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Index X To Accumulator</para>
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
    public class TXA : Instruction
    {
        public override string Name => "TXA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x8A, Implied.Instance)
        };


        public TXA() { }
        public TXA(byte[] instructionData) => this.instructionData = instructionData;
    }
}