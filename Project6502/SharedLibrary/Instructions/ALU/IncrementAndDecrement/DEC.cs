using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Decrement Memory By One</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the difference is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the decrement is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class DEC : Instruction
    {
        public override string Name => "DEC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xCE, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0xDE, AbsoluteX.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xC6, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0xD6, ZeroPageX.Instance)
        };

        public DEC() { }
        public DEC(byte[] instructionData) => this.instructionData = instructionData;
    }
}