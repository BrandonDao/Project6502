using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Store Accumulator in Memory</para>
    /// </summary>
    public class STA : Instruction
    {
        public override string Name => "STA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x8D, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x9D, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0x99, AbsoluteY.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x85, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x95, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0x81, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0x91, ZeroPageIndirectY.Instance)
        };

        public STA() { }
        public STA(byte[] instructionData) => this.instructionData = instructionData;
    }
}
