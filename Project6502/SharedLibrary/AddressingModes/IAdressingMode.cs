namespace SharedLibrary.AddressingModes
{
    public interface IAddressingMode
    {
        public string Pattern { get; }
        public byte Length { get; }
        public byte[] Parser(byte opcode, string address);
    }
}