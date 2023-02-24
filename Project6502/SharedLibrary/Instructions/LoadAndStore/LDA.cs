using SharedLibrary.Layouts;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.LoadAndStore
{
    public class LDA : Instruction
    {
        private readonly LDALayout LDALayout = new();

        public override string RegexPattern => LDALayout.RegexPattern;
        public override RegexOptions RegexOptions => LDALayout.RegexOptions;
        protected override ILayout layout => LDALayout;

        public LDA() { }
        public LDA(byte[] instructionData) => this.instructionData = instructionData;
    }
}