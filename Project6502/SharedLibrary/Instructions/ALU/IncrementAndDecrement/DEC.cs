namespace SharedLibrary.Instructions.ALU.IncrementAndDecrement
{
    public class DEC : Instruction
    {
        public override string Name => "DEC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xCE,
            [RegexPatterns.AbsoluteX] = 0xDE,
            [RegexPatterns.ZP] = 0xC6,
            [RegexPatterns.ZPX] = 0xD6
        };

        public DEC() { }
        public DEC(byte[] instructionData) => this.instructionData = instructionData;
    }
}