namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteX : IAddressingMode
    {
        public static AbsoluteX Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}, *X\Z";
        public byte InstructionLength => 3;
        public byte[] Parse(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}