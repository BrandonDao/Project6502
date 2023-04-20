namespace SharedLibrary.AddressingModes.ZeroPage
{
    public class ZeroPageIndirectY : IAddressingMode
    {
        public static ZeroPageIndirectY Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{2}\), *Y(?:\Z|\r)";
        public byte Length => 2;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}