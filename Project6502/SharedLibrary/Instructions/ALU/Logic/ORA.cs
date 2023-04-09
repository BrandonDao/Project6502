namespace SharedLibrary.Instructions.ALU.Logic
{
    public class ORA : Instruction
    {
        public override string Name => "ORA";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x0D,
            [RegexPatterns.AbsoluteX] = 0x1D,
            [RegexPatterns.AbsoluteY] = 0x19,
            [RegexPatterns.Immediate] = 0x09,
            [RegexPatterns.ZP] = 0x05,
            [RegexPatterns.ZPX] = 0x15,
            [RegexPatterns.ZPXIndirect] = 0x01,
            [RegexPatterns.ZPIndirectY] = 0x11,
        };

        public ORA() { }
        public ORA(byte[] instructionData) => this.instructionData = instructionData;
    }
}