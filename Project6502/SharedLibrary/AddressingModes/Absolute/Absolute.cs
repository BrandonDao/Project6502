namespace SharedLibrary.AddressingModes.Absolute
{
    public class Absolute : IAddressingMode
    {
        public static Absolute Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{4}\Z";
        public byte InstructionLength => 3;
        public byte[] Parse(byte opcode, string address)
            => new byte[]
            {
                opcode,
                byte.Parse(address[..2], System.Globalization.NumberStyles.AllowHexSpecifier),
                byte.Parse(address[2..], System.Globalization.NumberStyles.AllowHexSpecifier)
            };
    }
}