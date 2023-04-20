using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Misc;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Break Command</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>I (Interrupt)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class BRK : Instruction
    {
        public override string Name => "BRK";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingPatternToInfo => new()
        {
            [Implied.Instance] = new InstructionInfo(0x00, Implied.Instance)
        };

        public BRK() { }
        public BRK(byte[] instructionData) => this.instructionData = instructionData;
    }
}