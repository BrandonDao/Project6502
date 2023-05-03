using SharedLibrary.AddressingModes;
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
            [Implied.Instance] = new InstructionInfo(0xB0, Implied.Instance)
        };

        public BCS() { }
        public BCS(byte[] instructionData) => this.instructionData = instructionData;
    }
}