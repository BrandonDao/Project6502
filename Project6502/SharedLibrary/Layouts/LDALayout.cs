using System.Globalization;
using System.Text.RegularExpressions;
using SharedLibrary;

namespace SharedLibrary.Layouts
{
    public class LDALayout : ILayout
    {
        public string RegexPattern => @"LDA (?:(?:(#)\$([\da-z]{2})(?:\Z|\r))|(?:(\(?)\$([\da-z]{4}|[\da-z]{2}),?([XY]?))\r?)";
        public RegexOptions RegexOptions => RegexOptions.IgnoreCase;

        public Dictionary<AddressingModes, byte> ModeToOpcode => new()
        {
            [AddressingModes.Absolute] = 0xAD,
            [AddressingModes.Absolute | AddressingModes.XIndexed] = 0xBD,
            [AddressingModes.Absolute | AddressingModes.YIndexed] = 0xB9,
            [AddressingModes.Immediate] = 0xA9,
            [AddressingModes.ZeroPage] = 0xA5,
            [AddressingModes.ZeroPage | AddressingModes.XIndexed] = 0x61,
            [AddressingModes.ZeroPage | AddressingModes.XIndexed | AddressingModes.Indirect] = 0xA1,
            [AddressingModes.ZeroPage | AddressingModes.YIndexed | AddressingModes.Indirect] = 0x71
        };

        public byte[] Parse(Match match)
        {
            

            if (match.Groups[1].Success) // #
            {
                return new byte[] { ModeToOpcode[AddressingModes.Immediate], byte.Parse(match.Groups[2].Value, NumberStyles.AllowHexSpecifier) };
            }
            ;

            throw new NotImplementedException();
        }
    }
}