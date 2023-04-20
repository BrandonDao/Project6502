using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Branch
{
    /// <summary>
    /// <para>Branch on Overflow Set</para>
    /// </summary>
    public class BVS : Instruction
    {
        public override string Name => "BVS";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x70, Implied.Instance)
        };

        public BVS() { }
        public BVS(byte[] instructionData) => this.instructionData = instructionData;
    }
}