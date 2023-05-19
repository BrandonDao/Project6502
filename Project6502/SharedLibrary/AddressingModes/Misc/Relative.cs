namespace SharedLibrary.AddressingModes.Misc
{
    public class Relative : IAddressingMode
    {
        public static Relative Instance { get; } = new();

        public string Pattern => @"^ *\$[\dA-Z]{2}\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => new byte[]
            {
                opcode,
                byte.Parse(address, System.Globalization.NumberStyles.AllowHexSpecifier)
            };
    }
}