namespace SharedLibrary.Layouts
{
    public interface ILayout
    {
        public Dictionary<string, byte> AddressingPatternToOpcode { get; }

        public string Name { get; }
    }
}