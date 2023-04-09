namespace SharedLibrary.Instructions.Subroutines
{
    public class JMP : Instruction
    {
        public override string Name => "JMP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4C,
            [RegexPatterns.AbsoluteIndirect] = 0x6C,
        };

        public JMP() { }
        public JMP(byte[] instructionData) => this.instructionData = instructionData;
    }
}