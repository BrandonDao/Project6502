using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Index X To Stack Pointer</para>
    /// </summary>
    public class TXS : Instruction
    {
        public override string Name => "TXS";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x9A, Implied.Instance)
        };

        public TXS() { }
        public TXS(byte[] instructionData) => this.instructionData = instructionData;
    }
}