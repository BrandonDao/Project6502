namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageY : IAddressingMode
    {
        public static ZeroPageY Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}, *Y(?:\Z|\r)";
        public byte Length => 2;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}