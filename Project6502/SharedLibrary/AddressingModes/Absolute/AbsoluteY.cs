namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteY : IAddressingMode
    {
        public static AbsoluteY Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}, *Y\Z";
        public byte InstructionLength => 3;
        public byte[] Parse(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}