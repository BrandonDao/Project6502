using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    /// <summary>
    /// <para>Decrement Index Register X By One</para>
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
    public class DEX : Instruction
    {
        public override string Name => "DEX";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0xCA, Implied.Instance)
        };

        public DEX() { }
        public DEX(byte[] instructionData) => this.instructionData = instructionData;
    }
}