using SharedLibrary.AddressingModes.Absolute;

namespace SharedLibrary.AddressingModes.Misc
{
    public class RelativeLabeled : IAddressingMode
    {
        public static RelativeLabeled Instance { get; } = new();

        public string Pattern => @"^ *[A-Z]+ *\Z";
        public byte InstructionLength => 2;
        public byte[] Parse(byte opcode, string address)
            => throw new NotImplementedException("This addressing mode is used solely for regex matching labels!");
    }
}