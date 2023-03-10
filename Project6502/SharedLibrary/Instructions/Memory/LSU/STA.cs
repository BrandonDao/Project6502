namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    public class STA : Instruction
    {
        public override string Name => "STA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x8D,
            [RegexPatterns.AbsoluteX] = 0x9D,
            [RegexPatterns.AbsoluteY] = 0x99,
            [RegexPatterns.ZP] = 0x85,
            [RegexPatterns.ZPX] = 0x95,
            [RegexPatterns.ZPXIndirect] = 0x81,
            [RegexPatterns.ZPIndirectY] = 0x91
        };

        public STA() { }
        public STA(byte[] instructionData) => this.instructionData = instructionData;
    }
}
