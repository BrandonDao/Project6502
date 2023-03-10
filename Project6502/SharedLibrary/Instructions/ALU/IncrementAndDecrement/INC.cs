namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    public class INC : Instruction
    {
        public override string Name => "INC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xEE,
            [RegexPatterns.AbsoluteX] = 0xFE,
            [RegexPatterns.ZP] = 0xE6,
            [RegexPatterns.ZPX] = 0xF6
        };

        public INC() { }
        public INC(byte[] instructionData) => this.instructionData = instructionData;
    }
}