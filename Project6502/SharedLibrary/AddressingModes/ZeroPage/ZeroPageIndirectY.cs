namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageIndirectY : IAddressingMode
    {
        public static ZeroPageIndirectY Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{2}\), *Y\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => ZeroPage.Instance.Parse(opcode, address);
    }
}