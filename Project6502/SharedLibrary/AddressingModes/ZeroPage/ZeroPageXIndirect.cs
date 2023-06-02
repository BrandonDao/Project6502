namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageXIndirect : IAddressingMode
    {
        public static ZeroPageXIndirect Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{2}, *X\)\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => new byte[]
            {
                opcode,
                byte.Parse(address[2..4], System.Globalization.NumberStyles.AllowHexSpecifier)
            };
    }
}