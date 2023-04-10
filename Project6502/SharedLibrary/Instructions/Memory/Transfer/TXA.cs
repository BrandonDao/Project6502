namespace SharedLibrary.Instructions.LSU.Transfer
{
    /// <summary>
    /// <para>Transfer Index X To Accumulator</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set if bit 7 of the accumulator after the transfer is 1</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the accumulator is 0 after the transfer</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class TXA : Instruction
    {
        public override string Name => "TXA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException();
        private const byte opcode = 0x8A;


        public TXA() { }
        public TXA(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode };
        }
    }
}