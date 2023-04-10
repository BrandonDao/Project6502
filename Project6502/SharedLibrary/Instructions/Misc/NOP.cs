namespace SharedLibrary.Instructions.Misc
{
    /// <summary>
    /// <para>No Operation</para>
    /// </summary>
    public class NOP : Instruction
    {
        public override string Name => "NOP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0xEA;

        public NOP() { }
        public NOP(byte[] instructionData) => this.instructionData = instructionData;

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