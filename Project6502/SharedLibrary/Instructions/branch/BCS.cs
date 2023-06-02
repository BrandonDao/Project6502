using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Carry Set</para>
    /// </summary>
    public class BCS : Instruction
    {
        public override string Name => "BCS";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0xB0, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0xB0, RelativeLabeled.Instance)
        };

        public BCS() { }
        public BCS(byte[] instructionData) => this.instructionData = instructionData;
    }
}