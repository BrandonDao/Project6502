namespace SharedLibrary.Instructions.LoadAndStore
{
    public class STY : Instruction
    {
        public override string Name => "STY";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x8E,
            [RegexPatterns.ZP] = 0x86,
            [RegexPatterns.ZPY] = 0x96
        };

        public STY() { }
        public STY(byte[] instructionData) => this.instructionData = instructionData;
    }
}