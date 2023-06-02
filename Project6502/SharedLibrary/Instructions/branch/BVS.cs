using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Overflow Set</para>
    /// </summary>
    public class BVS : Instruction
    {
        public override string Name => "BVS";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0x70, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0x70, RelativeLabeled.Instance)
        };

        public BVS() { }
        public BVS(byte[] instructionData) => this.instructionData = instructionData;
    }
}