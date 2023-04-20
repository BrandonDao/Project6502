namespace SharedLibrary.AddressingModes.Misc
{
    public class Relative : IAddressingMode
    {
        public static Relative Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}(?:\Z|\r)";
        public byte Length => 2;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}