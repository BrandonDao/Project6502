namespace SharedLibrary.AddressingModes.Misc
{
    public class Immediate : IAddressingMode
    {
        public static Immediate Instance { get; } = new();

        public string Pattern => @"^ *#\$[\dA-Z]{2}\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
        {
            throw new NotImplementedException();
        }
    }
}