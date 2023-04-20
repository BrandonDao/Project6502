namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageX : IAddressingMode
    {
        public static ZeroPageX Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}, *X(?:\Z|\r)";
        public byte Length => 2;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}