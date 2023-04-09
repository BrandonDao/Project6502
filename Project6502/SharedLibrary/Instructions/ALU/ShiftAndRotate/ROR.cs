namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    public class ROR : Instruction
    {
        public override string Name => "ROR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x6E,
            [RegexPatterns.AbsoluteX] = 0x7E,
            [RegexPatterns.Accumulator] = 0x6A,
            [RegexPatterns.ZP] = 0x66,
            [RegexPatterns.ZPX] = 0x76
        };

        public ROR() { }
        public ROR(byte[] instructionData) => this.instructionData = instructionData;
    }
}