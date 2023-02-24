namespace SharedLibrary
{
    [Flags]
    public enum AddressingModes : byte
    {
        Accumulator = 0x00,
        Implied = 0x01,
        Immediate = 0x02,
        Absolute = 0x04,
        ZeroPage = 0x08,
        Relative = 0x10,
        XIndexed = 0x20,
        YIndexed = 0x40,
        Indirect = 0x80,
    }
}
