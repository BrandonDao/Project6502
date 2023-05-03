using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Not Zero</para>
    /// </summary>
    public class BNE : Instruction
    {
        public override string Name => "BNE";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xD0, Implied.Instance)
        };

        public BNE() { }
        public BNE(byte[] instructionData) => this.instructionData = instructionData;
    }
}