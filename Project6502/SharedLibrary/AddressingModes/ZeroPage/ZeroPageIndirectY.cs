namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageIndirectY : IAddressingMode
    {
        public static ZeroPageIndirectY Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{2}\), *Y\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => new byte[]
            {
                opcode,
                byte.Parse(address[2..4], System.Globalization.NumberStyles.AllowHexSpecifier)
            };
    }
}