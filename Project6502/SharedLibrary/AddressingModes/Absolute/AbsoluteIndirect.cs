namespace SharedLibrary.AddressingModes.Absolute
{
    public class AbsoluteIndirect : IAddressingMode
    {
        public static AbsoluteIndirect Instance { get; } = new();

        public string Pattern => @"^ *\(\$[\dA-Z]{4}\)\Z";
        public byte InstructionLength => 3;
        public byte[] Parse(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}