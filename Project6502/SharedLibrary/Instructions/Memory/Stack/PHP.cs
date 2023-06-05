using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.Stack
{
    /// <summary>
    /// <para>Push Processor Status On Stack</para>
    /// </summary>
    public class PHP : Instruction
    {
        public override string Name => "PHP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x08, Implied.Instance)
        };

        public PHP() { }
        public PHP(byte[] instructionData) => this.instructionData = instructionData;
    }
}