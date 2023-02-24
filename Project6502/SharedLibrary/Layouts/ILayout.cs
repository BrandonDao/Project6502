using System.Text.RegularExpressions;

namespace SharedLibrary.Layouts
{
    public interface ILayout
    {
        public Dictionary<AddressingModes, byte> ModeToOpcode { get; }

        public string RegexPattern { get; }
        public RegexOptions RegexOptions { get; }
        public byte[] Parse(Match match);
    }
}