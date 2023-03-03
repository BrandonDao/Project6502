using SharedLibrary.Layouts;

namespace SharedLibrary.Instructions.LoadAndStore
{
    public class LDA : Instruction
    {
        private readonly LDALayout LDALayout = new();

        public override string Name => LDALayout.Name;
        protected override ILayout Layout => LDALayout;

        public LDA() { }
        public LDA(byte[] instructionData) => this.instructionData = instructionData;
    }
}