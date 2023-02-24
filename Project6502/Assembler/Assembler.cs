using SharedLibrary.Instructions;

namespace Assembler
{
    public static class Assembler
    {
        public static byte[] Assemble(string[] assemblyProgram) => Instruction.Parse(assemblyProgram);
    }
}
