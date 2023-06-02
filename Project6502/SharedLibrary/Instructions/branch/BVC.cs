using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
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
            [Relative.Instance] = new InstructionInfo(0x50, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0x50, RelativeLabeled.Instance)
        };

        public BVC() { }
        public BVC(byte[] instructionData) => this.instructionData = instructionData;
    }
}