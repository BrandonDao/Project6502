namespace SharedLibrary.Layouts
{
    public class LDALayout : ILayout
    {
        public string Name => "LDA";

        public Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xAD,
            [RegexPatterns.AbsoluteX] = 0xBD,
            [RegexPatterns.AbsoluteY] = 0xB9,
            [RegexPatterns.Immediate] = 0xA9,
            [RegexPatterns.ZP] = 0xA5,
            [RegexPatterns.ZPX] = 0x61,
            [RegexPatterns.ZPXIndirect] = 0xA1,
            [RegexPatterns.ZPIndirectY] = 0x71
        };
    }
}