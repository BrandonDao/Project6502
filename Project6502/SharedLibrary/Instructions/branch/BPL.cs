using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Result Plus</para>
    /// </summary>
    public class BPL : Instruction
    {
        public override string Name => "BPL";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x10, Implied.Instance)
        };

        public BPL() { }
        public BPL(byte[] instructionData) => this.instructionData = instructionData;
    }
}