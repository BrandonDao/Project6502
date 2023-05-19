using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Increment Index Register Y By One</para>
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
    public class INY : Instruction
    {
        public override string Name => "INY";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xC8, Implied.Instance)
        };

        public INY() { }
        public INY(byte[] instructionData) => this.instructionData = instructionData;
    }
}