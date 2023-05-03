using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump Indirect</para>
    /// </summary>
    public class JMP : Instruction
    {
        public override string Name => "JMP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x4C, Absolute.Instance),
            [AbsoluteLabeled.Instance] = new InstructionInfo(0x4C, AbsoluteLabeled.Instance),
            [AbsoluteIndirect.Instance] = new InstructionInfo(0x6C, AbsoluteIndirect.Instance)
        };

        public JMP() { }
        public JMP(byte[] instructionData) => this.instructionData = instructionData;
    }
}