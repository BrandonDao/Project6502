using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump To Subroutine</para>
    /// </summary>
    public class JSR : Instruction
    {
        public override string Name => "JSR";

        public override Dictionary<string, byte> AddressingPatternToOpcode => new()
        {
            [RegexPatterns.Absolute] = 0x20,
        };

        public JSR() { }
        public JSR(byte[] instructionData) => this.instructionData = instructionData;

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