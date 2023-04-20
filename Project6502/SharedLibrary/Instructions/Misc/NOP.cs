using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Misc
{
    /// <summary>
    /// No Operation
    /// </summary>
    public class NOP : Instruction
    {
        public override string Name => "NOP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xEA, Implied.Instance)
        };

        public NOP() { }
        public NOP(byte[] instructionData) => this.instructionData = instructionData;
    }
}