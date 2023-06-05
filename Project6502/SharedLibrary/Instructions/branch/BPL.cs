using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Plus</para>
    /// </summary>
    public class BPL : Instruction
    {
        public override string Name => "BPL";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0x10, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0x10, RelativeLabeled.Instance)
        };

        public BPL() { }
        public BPL(byte[] instructionData) => this.instructionData = instructionData;
    }
}