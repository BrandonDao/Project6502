namespace SharedLibrary.AddressingModes
{
    public interface IAddressingMode
    {
        public string Pattern { get; }
        public byte InstructionLength { get; }
        public byte[] Parse(byte opcode, string address);
    }
}