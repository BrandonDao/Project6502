using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Logical Shift Right</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the result is 1 (will always be 0)</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to the bit shifted out of the input (bit 0)</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class LSR : Instruction
    {
        public override string Name => "LSR";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x4E, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x5E, AbsoluteX.Instance),
            [Implied.Instance] = new InstructionInfo(0x4A, Implied.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x46, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x56, ZeroPageX.Instance)
        };

        public LSR() { }
        public LSR(byte[] instructionData) => this.instructionData = instructionData;
    }
}