using System.Globalization;
using System.Net;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump Indirect</para>
    /// </summary>
    public class JMP : Instruction
    {
        public override string Name => "JMP";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x4C,
            [RegexPatterns.AbsoluteIndirect] = 0x6C,
        };

        public JMP() { }
        public JMP(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            var match = Regex.Match(asmInstruction, RegexPatterns.LabelReference);

            if (match.Success)
            {
                short address = LabelToLineNum[match.Groups[1].Value];
                byte msb = (byte)((address & 0xFF00) >> 8);
                byte lsb = (byte)(address & 0x00FF);

                return new byte[] { AddressingPatternToOpcode[RegexPatterns.Absolute], lsb, msb };
            }

            return base.GetInstructionData(lineNumber, asmInstruction, instruction);
        }
    }
}