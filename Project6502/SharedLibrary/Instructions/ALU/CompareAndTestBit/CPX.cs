namespace SharedLibrary.Instructions.ALU.CompareAndTestBit
{
    public class CPX : Instruction
    {
        public override string Name => "CPX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0xEC,
            [RegexPatterns.Immediate] = 0xE0,
            [RegexPatterns.ZP] = 0xE4
        };

        public CPX() { }
        public CPX(byte[] instructionData) => this.instructionData = instructionData;
    }
}