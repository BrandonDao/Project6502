namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageY : IAddressingMode
    {
        public static ZeroPageY Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}, *Y\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}