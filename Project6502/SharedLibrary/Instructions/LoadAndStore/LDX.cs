namespace SharedLibrary.Instructions.LoadAndStore
{
    public class LDX : Instruction
    {
        public override string Name => "LDX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAE,
            [RegexPatterns.AbsoluteY] = 0xBE,
            [RegexPatterns.Immediate] = 0xA2,
            [RegexPatterns.ZP] = 0xA6,
            [RegexPatterns.ZPY] = 0xB6
        };

        public LDX() { }
        public LDX(byte[] instructionData) => this.instructionData = instructionData;
    }
}