namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    public class ROL : Instruction
    {
        public override string Name => "ROL";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x2E,
            [RegexPatterns.AbsoluteX] = 0x3E,
            [RegexPatterns.Accumulator] = 0x2A,
            [RegexPatterns.ZP] = 0x26,
            [RegexPatterns.ZPX] = 0x36
        };

        public ROL() { }
        public ROL(byte[] instructionData) => this.instructionData = instructionData;
    }
}