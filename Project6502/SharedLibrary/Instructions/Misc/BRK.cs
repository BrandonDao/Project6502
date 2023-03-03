namespace SharedLibrary.Instructions.Misc
{
    public class BRK : Instruction
    {
        public override string Name => "BRK";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new Exception("Unused");
        private const byte opcode = 0xEA;

        public BRK() { }
        public BRK(byte[] instructionData) => this.instructionData = instructionData;

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