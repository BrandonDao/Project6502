namespace SharedLibrary.AddressingModes.Misc
{
    public class Implied : IAddressingMode
    {
        public static Implied Instance { get; } = new();

        public string Pattern => @"^ *(?:\Z|\r)";
        public byte Length => 1;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}