using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Memory.Stack
{
    /// <summary>
    /// <para>Push Accumulator On Stack</para>
    /// </summary>
    public class PHA : Instruction
    {
        public override string Name => "PHA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x48, Implied.Instance)
        };

        public PHA() { }
        public PHA(byte[] instructionData) => this.instructionData = instructionData;
    }
}