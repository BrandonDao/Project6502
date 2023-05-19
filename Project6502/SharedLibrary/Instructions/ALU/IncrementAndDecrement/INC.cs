using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Increment Memory By One</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the difference is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the increment is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class INC : Instruction
    {
        public override string Name => "INC";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0xEE, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0xFE, AbsoluteX.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0xE6, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0xF6, ZeroPageX.Instance)
        };

        public INC() { }
        public INC(byte[] instructionData) => this.instructionData = instructionData;
    }
}