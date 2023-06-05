using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Store Index Register Y in Memory</para>
    /// </summary>
    public class STY : Instruction
    {
        public override string Name => "STY";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x8C, Absolute.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x84, ZeroPage.Instance),
            [ZeroPageY.Instance] = new InstructionInfo(0x94, ZeroPageY.Instance)
        };

        public STY() { }
        public STY(byte[] instructionData) => this.instructionData = instructionData;
    }
}