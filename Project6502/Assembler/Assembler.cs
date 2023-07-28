using SharedLibrary.Instructions;

namespace Assembler
{
    public static class Assembler
    {
        public static void Assemble(string assemblySourceCodeFile)
        {
            string[] asm = File.ReadAllText(assemblySourceCodeFile).Split("\n");
            byte[] machineCode = Instruction.ToByteArray(Instruction.Parse(asm, memoryStartAddress: 0x8000));

            File.WriteAllBytes(@"..\..\..\Assembly\AssembledProgramBytes.bin", Linker.Link(machineCode));
        }
    }
}