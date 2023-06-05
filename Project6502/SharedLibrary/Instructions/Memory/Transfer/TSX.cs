using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Memory.Transfer
{
    /// <summary>
    /// <para>Transfer Stack Pointer To Index X</para>
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
    public class TSX : Instruction
    {
        public override string Name => "TSX";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xBA, Implied.Instance)
        };

        public TSX() { }
        public TSX(byte[] instructionData) => this.instructionData = instructionData;
    }
}