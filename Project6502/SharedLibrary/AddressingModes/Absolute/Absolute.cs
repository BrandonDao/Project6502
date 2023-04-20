namespace SharedLibrary.AddressingModes.Absolute
{
    public class Absolute : IAddressingMode
    {
        public static Absolute Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}(?:\Z|\r)";
        public byte Length => 3;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}