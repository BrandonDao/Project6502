namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    public class CMP : Instruction
    {
        public override string Name => "CMP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xCD,
            [RegexPatterns.AbsoluteX] = 0xDD,
            [RegexPatterns.AbsoluteY] = 0xD9,
            [RegexPatterns.Immediate] = 0xC9,
            [RegexPatterns.ZP] = 0xC5,
            [RegexPatterns.ZPX] = 0xD5,
            [RegexPatterns.ZPXIndirect] = 0xC1,
            [RegexPatterns.ZPIndirectY] = 0xD1
        };

        public CMP() { }
        public CMP(byte[] instructionData) => this.instructionData = instructionData;
    }
}