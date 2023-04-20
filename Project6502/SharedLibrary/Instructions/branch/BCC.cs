using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Misc
{
    /// <summary>
    /// <para>Branch on Carry Clear</para>
    /// </summary>
    public class BCC : Instruction
    {
        public override string Name => "BCC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x90, Implied.Instance)
        };

        public BCC() { }
        public BCC(byte[] instructionData) => this.instructionData = instructionData;
    }
}