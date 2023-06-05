using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Store Index Register X in Memory</para>
    /// </summary>
    public class STX : Instruction
    {
        public override string Name => "STX";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x8E, Absolute.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x86, ZeroPage.Instance),
            [ZeroPageY.Instance] = new InstructionInfo(0x96, ZeroPageY.Instance)
        };

        public STX() { }
        public STX(byte[] instructionData) => this.instructionData = instructionData;
    }
}
