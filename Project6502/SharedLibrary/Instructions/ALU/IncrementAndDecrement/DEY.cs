using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Decrement Index Register Y By One</para>
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
    public class DEY : Instruction
    {
        public override string Name => "DEY";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x88, Implied.Instance)
        };

        public DEY() { }
        public DEY(byte[] instructionData) => this.instructionData = instructionData;
    }
}