namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    public class LSR : Instruction
    {
        public override string Name => "LSR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4E,
            [RegexPatterns.AbsoluteX] = 0x5E,
            [RegexPatterns.Accumulator] = 0x4A,
            [RegexPatterns.ZP] = 0x46,
            [RegexPatterns.ZPX] = 0x56
        };

        public LSR() { }
        public LSR(byte[] instructionData) => this.instructionData = instructionData;
    }
}