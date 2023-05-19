namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteLabeled : IAddressingMode
    {
        public static AbsoluteLabeled Instance { get; } = new();

        public string Pattern => @"^ *[A-Z]+ *\Z";
        public byte InstructionLength => 3;
        public byte[] Parse(byte opcode, string address)
            => throw new NotImplementedException("This addressing mode is used solely for regex matching labels!");
    }
}