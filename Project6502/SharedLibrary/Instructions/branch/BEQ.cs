using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Zero</para>
    /// </summary>
    public class BEQ : Instruction
    {
        public override string Name => "BEQ";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0xF0, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0xF0, RelativeLabeled.Instance)
        };

        public BEQ() { }
        public BEQ(byte[] instructionData) => this.instructionData = instructionData;
    }
}