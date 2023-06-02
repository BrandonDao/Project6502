using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Minus</para>
    /// </summary>
    public class BMI : Instruction
    {
        public override string Name => "BMI";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Relative.Instance] = new InstructionInfo(0x30, Relative.Instance),
            [RelativeLabeled.Instance] = new InstructionInfo(0x30, RelativeLabeled.Instance)
        };

        public BMI() { }
        public BMI(byte[] instructionData) => this.instructionData = instructionData;
    }
}