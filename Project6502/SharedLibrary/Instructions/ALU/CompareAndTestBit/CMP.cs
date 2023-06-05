using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    /// <summary>
    /// <para>Compare Memory and Accumulator</para>
    /// <para>Subtracts contents of Memory from contents of Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the difference is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set if contents of memory >= contents of accumulator</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class CMP : Instruction
    {
        public override string Name => "CMP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo=> new()
        {
            [Absolute.Instance] = new InstructionInfo(0xCD, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0xDD, AbsoluteX.Instance),
            [AbsoluteY.Instance] = new InstructionInfo(0xD9, AbsoluteY.Instance),
            [Immediate.Instance] = new InstructionInfo(0xC9, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xC5, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0xD5, ZeroPageX.Instance),
            [ZeroPageXIndirect.Instance] = new InstructionInfo(0xC1, ZeroPageXIndirect.Instance),
            [ZeroPageIndirectY.Instance] = new InstructionInfo(0xD1, ZeroPageIndirectY.Instance)
        };

        public CMP() { }
        public CMP(byte[] instructionData) => this.instructionData = instructionData;
    }
}