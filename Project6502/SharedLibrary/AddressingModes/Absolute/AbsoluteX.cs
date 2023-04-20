namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteX : IAddressingMode
    {
        public static AbsoluteX Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}, *X(?:\Z|\r)";
        public byte Length => 3;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}