using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Misc
{
    /// <summary>
    /// <para>Branch on Carry Clear</para>
    /// </summary>
    public class BCC : Instruction
    {
        public override string Name => "BCC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0x90, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0x90, RelativeLabeled.Instance)
        };

        public BCC() { }
        public BCC(byte[] instructionData) => this.instructionData = instructionData;
    }
}