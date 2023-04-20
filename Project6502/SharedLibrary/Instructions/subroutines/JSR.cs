using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump To Subroutine</para>
    /// </summary>
    public class JSR : Instruction
    {
        public override string Name => "JSR";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x20, Absolute.Instance)
        };

        public JSR() { }
        public JSR(byte[] instructionData) => this.instructionData = instructionData;
    }
}