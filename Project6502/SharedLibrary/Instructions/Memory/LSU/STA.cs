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

        private static Dictionary<byte, Action<byte[], byte[], CPU>> OpCodeToExecutor => new()
        {
            [0x8D] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[(instructionInfo[1] << 8) | instructionInfo[0]] = CPU.RA; },
            [0x9D] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[(instructionInfo[1] << 8) | instructionInfo[0] + CPU.RX] = CPU.RA; },
            [0x99] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[(instructionInfo[1] << 8) | instructionInfo[0] + CPU.RY] = CPU.RA; },
            [0x85] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[instructionInfo[0]] = CPU.RA; },
            [0x95] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[instructionInfo[0] + CPU.RX] = CPU.RA; },
            [0x81] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[memory[instructionInfo[0] << 8 | instructionInfo[0] + CPU.RX]] = CPU.RA; },
            [0x91] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { memory[memory[instructionInfo[0] << 8 | instructionInfo[0]] + CPU.RY] = CPU.RA; },
        };

        public STA() { }
        public STA(byte[] instructionData) => InstructionData = instructionData;

        public override void Execute(byte opCode, byte[] instructionData, byte[] memory, CPU CPU)
            => OpCodeToExecutor[opCode].Invoke(instructionData, memory, CPU);
    }
}
