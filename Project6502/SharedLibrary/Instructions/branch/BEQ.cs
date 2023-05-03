using SharedLibrary.AddressingModes;
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
            [Implied.Instance] = new(0xF0, Implied.Instance)
        };

        public BEQ() { }
        public BEQ(byte[] instructionData) => this.instructionData = instructionData;
    }
}