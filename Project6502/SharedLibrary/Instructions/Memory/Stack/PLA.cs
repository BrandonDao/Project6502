namespace SharedLibrary.Instructions.Memory.Stack
{
    public class PLA : Instruction
    {
        public override string Name => "PLA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x68;

        public PLA() { }
        public PLA(byte[] instructionData) => this.instructionData = instructionData;

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