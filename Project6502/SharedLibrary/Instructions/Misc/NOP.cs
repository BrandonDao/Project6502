namespace SharedLibrary.Instructions.Misc
{
    public class NOP : Instruction
    {
        public override string Name => "NOP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new Exception("Unused");
        private const byte opcode = 0x00;

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