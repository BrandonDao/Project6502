namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    public class CPY : Instruction
    {
        public override string Name => "CPY";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xCC,
            [RegexPatterns.Immediate] = 0xC0,
            [RegexPatterns.ZP] = 0xC4
        };

        public CPY() { }
        public CPY(byte[] instructionData) => this.instructionData = instructionData;
    }
}