using SharedLibrary.Layouts;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public abstract string RegexPattern { get; }
        public abstract RegexOptions RegexOptions { get; }
        protected abstract ILayout layout { get; }
        protected byte[] instructionData;



        public static byte[] Parse(string[] assemblyInstructions)
        {
            LDALayout layout = new();
            var test = layout.Parse(Regex.Match(assemblyInstructions[0], layout.RegexPattern, layout.RegexOptions));

            throw new NotImplementedException();
        }
    }
}