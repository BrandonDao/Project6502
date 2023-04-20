using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Return From Subroutine</para>
    /// </summary>
    public class RTS : Instruction
    {
        public override string Name => "RTS";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x60, Implied.Instance)
        };

        public RTS() { }
        public RTS(byte[] instructionData) => this.instructionData = instructionData;
    }
}