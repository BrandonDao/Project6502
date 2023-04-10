namespace SharedLibrary.Instructions.LSU.LoadAndStore
{
    /// <summary>
    /// <para>Store Index Register X in Memory</para>
    /// </summary>
    public class STX : Instruction
    {
        public override string Name => "STX";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x8E,
            [RegexPatterns.ZP] = 0x86,
            [RegexPatterns.ZPY] = 0x96
        };

        public STX() { }
        public STX(byte[] instructionData) => this.instructionData = instructionData;
    }
}
