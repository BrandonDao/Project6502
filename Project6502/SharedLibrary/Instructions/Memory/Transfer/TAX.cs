using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Accumulator To Index X</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of register X after the transfer is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if register X is 0 after the transfer</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class TAX : Instruction
    {
        public override string Name => "TAX";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xAA, Implied.Instance)
        };

        public TAX() { }
        public TAX(byte[] instructionData) => this.instructionData = instructionData;
    }
}