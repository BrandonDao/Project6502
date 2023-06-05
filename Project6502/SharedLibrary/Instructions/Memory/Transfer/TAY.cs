using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Accumulator To Index Y</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of register Y after the transfer is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if register Y is 0 after the transfer</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class TAY : Instruction
    {
        public override string Name => "TAY";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xA8, Implied.Instance)
        };

        public TAY() { }
        public TAY(byte[] instructionData) => this.instructionData = instructionData;
    }
}