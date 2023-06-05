using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    /// <summary>
    /// <para>Test Bits in Memory with Accumulator</para>
    /// <para>Performs an AND on Memory and Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set to bit 7 of Memory</description>
    ///     </item>
    ///     <item>
    ///         <term>V (Overflow)</term>
    ///         <description>Set to bit 6 of Memory</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set to the result of the operation</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class BIT : Instruction
    {
        public override string Name => "BIT";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x2C, Absolute.Instance),
            [Immediate.Instance] = new InstructionInfo(0x89, Immediate.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x24, ZeroPage.Instance)
        };

        public BIT() { }
        public BIT(byte[] instructionData) => this.instructionData = instructionData;
    }
}