namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    public class BIT : Instruction
    {
        public override string Name => "BIT";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x2C,
            [RegexPatterns.Immediate] = 0x89,
            [RegexPatterns.ZP] = 0x24
        };

        public BIT() { }
        public BIT(byte[] instructionData) => this.instructionData = instructionData;
    }
}