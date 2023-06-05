using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.Memory.Stack
{
    /// <summary>
    /// <para>Pull Accumulator From Stack</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the accumulator is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the value of the accumulator is 0</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class PLA : Instruction
    {
        public override string Name => "PLA";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x68, Implied.Instance)
        };

        public PLA() { }
        public PLA(byte[] instructionData) => this.instructionData = instructionData;
    }
}