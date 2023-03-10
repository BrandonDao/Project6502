namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    public class ASL : Instruction
    {
        public override string Name => "ASL";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x0E,
            [RegexPatterns.AbsoluteX] = 0x1E,
            [RegexPatterns.Accumulator] = 0x0A,
            [RegexPatterns.ZP] = 0x06,
            [RegexPatterns.ZPX] = 0x16
        };

        public ASL() { }
        public ASL(byte[] instructionData) => this.instructionData = instructionData;
    }
}