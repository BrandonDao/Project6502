namespace SharedLibrary.AddressingModes.Misc
{
    public class Implied : IAddressingMode
    {
        public static Implied Instance { get; } = new();

        public string Pattern => @"^ *\Z";
        public byte InstructionLength => 1;
        public byte[] Parse(byte opcode, string address)
            => new byte[]
            {
                opcode
            };
    }
}