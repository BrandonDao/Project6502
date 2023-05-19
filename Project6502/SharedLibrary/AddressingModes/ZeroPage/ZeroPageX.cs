namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageX : IAddressingMode
    {
        public static ZeroPageX Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}, *X\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => ZeroPage.Instance.Parse(opcode, address);
    }
}