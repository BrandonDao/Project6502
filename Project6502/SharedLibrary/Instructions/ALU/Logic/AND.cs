namespace SharedLibrary.Instructions.ALU.Logic
{
    public class AND : Instruction
    {
        public override string Name => "AND";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x2D,
            [RegexPatterns.AbsoluteX] = 0x3D,
            [RegexPatterns.AbsoluteY] = 0x39,
            [RegexPatterns.Immediate] = 0x29,
            [RegexPatterns.ZP] = 0x25,
            [RegexPatterns.ZPX] = 0x35,
            [RegexPatterns.ZPXIndirect] = 0x21,
            [RegexPatterns.ZPIndirectY] = 0x31,
        };

        public AND() { }
        public AND(byte[] instructionData) => this.instructionData = instructionData;
    }
}