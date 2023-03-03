namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    public class LDY : Instruction
    {
        public override string Name => "LDY";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAC,
            [RegexPatterns.AbsoluteY] = 0xBC,
            [RegexPatterns.Immediate] = 0xA0,
            [RegexPatterns.ZP] = 0xA4,
            [RegexPatterns.ZPY] = 0xB4
        };

        public LDY() { }
        public LDY(byte[] instructionData) => this.instructionData = instructionData;
    }
}