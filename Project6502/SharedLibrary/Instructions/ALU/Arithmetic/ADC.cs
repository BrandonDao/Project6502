namespace SharedLibrary.Instructions.ALU.Arithmetic
{
    public class ADC : Instruction
    {
        public override string Name => "ADC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x6D,
            [RegexPatterns.AbsoluteX] = 0x7D,
            [RegexPatterns.AbsoluteY] = 0x79,
            [RegexPatterns.Immediate] = 0x69,
            [RegexPatterns.ZP] = 0x65,
            [RegexPatterns.ZPX] = 0x75,
            [RegexPatterns.ZPXIndirect] = 0x61,
            [RegexPatterns.ZPIndirectY] = 0x71
        };

        public ADC() { }
        public ADC(byte[] instructionData) => this.instructionData = instructionData;
    }
}