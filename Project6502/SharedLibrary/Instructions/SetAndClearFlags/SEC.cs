namespace SharedLibrary.Instructions.SetAndClearFlags
{
    /// <summary>
    /// <para>Set Carry Flag</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to 1</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class SEC : Instruction
    {
        public override string Name => "SEC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unusedd");
        private const byte opcode = 0x38;

        public SEC() { }
        public SEC(byte[] instructionData) => this.instructionData = instructionData;

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