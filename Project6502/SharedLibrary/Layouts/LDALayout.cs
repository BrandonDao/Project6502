using System.Globalization;

namespace SharedLibrary.Layouts
{
    public class LDALayout : ILayout
    {
        public string Name => "LDA";

        public Dictionary<string, byte> OpcodeByAddressingModePattern => new()
        {
            [RegexPatterns.Absolute] = 0xAD,
            [RegexPatterns.AbsoluteX] = 0xBD,
            [RegexPatterns.AbsoluteY] = 0xB9,
            [RegexPatterns.Immediate] = 0xA9,
            [RegexPatterns.ZP] = 0xA5,
            [RegexPatterns.ZPX] = 0x61,
            [RegexPatterns.ZPXIndirect] = 0xA1,
            [RegexPatterns.ZPYIndirect] = 0x71
        };

        public byte[] Parse(string asmInstruction)
        {
            if (match.Groups[1].Success) // #
            {
                return new byte[]
                {
                    ModeToOpcode[AddressingMode.Immediate],
                    byte.Parse(match.Groups[2].Value, NumberStyles.AllowHexSpecifier)
                };
            }
            else if (match.Groups[3].Value.Equals('(')) // zero-paged indirect indexed
            {
                AddressingMode indexType = match.Groups[5].Value.Equals('X') ? AddressingMode.XIndexed : AddressingMode.YIndexed;

                return new byte[]
                {
                    ModeToOpcode[AddressingMode.ZeroPage | AddressingMode.Indirect | indexType],
                    byte.Parse(match.Groups[4].Value, NumberStyles.AllowHexSpecifier)
                };
            }
            else
            {
                bool indexed = false;
                AddressingMode indexType;
                if (match.Groups[5].Value.Length != 0)
                {
                    indexed = true;
                    indexType = match.Groups[5].Value.Equals('X') ? AddressingMode.XIndexed : AddressingMode.YIndexed;
                }

                if (match.Groups[4].Value.Length == 2) // zero-paged (indexed)?
                {
                    return new byte[]
                    {
                        ModeToOpcode[AddressingMode.ZeroPage],
                        byte.Parse(match.Groups[4].Value, NumberStyles.AllowHexSpecifier)
                    };
                }
                else // absolute (indexed)?
                {
                    short address = short.Parse(match.Groups[4].Value, NumberStyles.AllowHexSpecifier);

                    return new byte[]
                    {
                        ModeToOpcode[AddressingMode.Absolute],
                        (byte)(address & 0x0000_00FF),
                        (byte)((address & 0x0000_FF00) >> 8)
                    };
                }
            }
        }
    }
}