namespace SharedLibrary.Instructions.ALU.Logic
{
    public class EOR : Instruction
    {
        public override string Name => "EOR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4D,
            [RegexPatterns.AbsoluteX] = 0x5D,
            [RegexPatterns.AbsoluteY] = 0x59,
            [RegexPatterns.Immediate] = 0x49,
            [RegexPatterns.ZP] = 0x45,
            [RegexPatterns.ZPX] = 0x55,
            [RegexPatterns.ZPXIndirect] = 0x41,
            [RegexPatterns.ZPIndirectY] = 0x51,
        };

        public EOR() { }
        public EOR(byte[] instructionData) => this.instructionData = instructionData;
    }
}