namespace SharedLibrary.Instructions.LSU.Transfer
{
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