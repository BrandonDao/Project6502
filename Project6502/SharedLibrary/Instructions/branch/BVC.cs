using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Overflow Clear</para>
    /// </summary>
    public class BVC : Instruction
    {
        public override string Name => "BVC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x50, Implied.Instance)
        };

        public BVC() { }
        public BVC(byte[] instructionData) => this.instructionData = instructionData;
    }
}