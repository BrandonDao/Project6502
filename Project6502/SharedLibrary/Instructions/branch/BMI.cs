using SharedLibrary.AddressingModes;
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
            [Implied.Instance] = new InstructionInfo(0x30, Implied.Instance)
        };

        public BMI() { }
        public BMI(byte[] instructionData) => this.instructionData = instructionData;
    }
}