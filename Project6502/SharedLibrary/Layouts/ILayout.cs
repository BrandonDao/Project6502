namespace SharedLibrary.Layouts
{
    public interface ILayout
    {
        public Dictionary<string, byte> OpcodeByAddressingModePattern { get; }

        public string Name { get; }

        public byte[] Parse(string asmInstruction);
    }
}