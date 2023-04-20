namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteLabeled : IAddressingMode
    {
        public static AbsoluteLabeled Instance { get; } = new();

        public string Pattern => @"^ *[A-Z]+ *(?:\Z|\r)";
        public byte Length => 3;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}