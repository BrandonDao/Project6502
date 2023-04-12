namespace SharedLibrary.Instructions.Memory.Stack
{
    /// <summary>
    /// <para>Push Accumulator On Stack</para>
    /// </summary>
    public class PHA : Instruction
    {
        public override string Name => "PHA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x48;

        public PHA() { }
        public PHA(byte[] instructionData) => this.instructionData = instructionData;


        protected override byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode };
        }
    }
}