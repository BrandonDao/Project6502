namespace Assembler
{
    public class Program
    {
        public static string[] LoadAssemblyProgram() => File.ReadAllText(@"..\..\..\Assembly\AssemblyProgram.asm").Split("\n");

        static void Main()
        {
            byte[] asm = Assembler.Assemble(LoadAssemblyProgram());

            File.WriteAllBytes(@"..\..\..\Assembly\AssembledProgramBytes.bin", Linker.Link(asm));
        }
    }
}