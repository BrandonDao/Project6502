namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteY : IAddressingMode
    {
        public static AbsoluteY Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}, *Y(?:\Z|\r)";
        public byte Length => 3;
        public byte[] Parser(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}