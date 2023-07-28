using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Load Accumulator with Memory</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if the bit 7 of the accumulator after the load is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the accumulator is 0 after the load</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LDA : Instruction
    {
        public override string Name => "LDA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xAD, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0xBD, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0xB9, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0xA9, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xA5, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0xB5, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0xA1, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0xB1, ZeroPageIndirectY.Instance)
        };

        private static Dictionary<byte, Action<byte[], byte[], CPU>> OpCodeToExecutor => new()
        {
            [0xAD] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[(instructionInfo[1] << 8) | instructionInfo[0]]; },
            [0xBD] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[(instructionInfo[1] << 8) | instructionInfo[0] + CPU.RX]; },
            [0xB9] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[(instructionInfo[1] << 8) | instructionInfo[0] + CPU.RY]; },
            [0xA9] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = instructionInfo[0]; },
            [0xA5] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[instructionInfo[0]]; },
            [0xB5] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[instructionInfo[0] + CPU.RX]; },
            [0xA1] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[memory[instructionInfo[0] << 8 | instructionInfo[0] + CPU.RX]]; },
            [0xB1] = (byte[] instructionInfo, byte[] memory, CPU CPU) => { CPU.RA = memory[memory[instructionInfo[0] << 8 | instructionInfo[0]] + CPU.RY]; },
        };

        public LDA() { }
        public LDA(byte[] instructionData) => InstructionData = instructionData;

        public override void Execute(byte opCode, byte[] instructionData, byte[] memory, CPU CPU)
            => OpCodeToExecutor[opCode].Invoke(instructionData, memory, CPU);
    }
}