namespace SharedLibrary.Instructions.ALU.Arithmetic
{
    public class SBC : Instruction
    {
        public override string Name => "ADC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xED,
            [RegexPatterns.AbsoluteX] = 0xFD,
            [RegexPatterns.AbsoluteY] = 0xF9,
            [RegexPatterns.Immediate] = 0xE9,
            [RegexPatterns.ZP] = 0xE5,
            [RegexPatterns.ZPX] = 0xEF,
            [RegexPatterns.ZPXIndirect] = 0xE1,
            [RegexPatterns.ZPIndirectY] = 0xF1
        };

        public SBC() { }
        public SBC(byte[] instructionData) => this.instructionData = instructionData;
    }
}