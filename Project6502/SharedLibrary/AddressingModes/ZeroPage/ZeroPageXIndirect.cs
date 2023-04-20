namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageXIndirect : IAddressingMode
    {
        public static ZeroPageXIndirect Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{2}, *X\)(?:\Z|\r)";
        public byte Length => 2;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}