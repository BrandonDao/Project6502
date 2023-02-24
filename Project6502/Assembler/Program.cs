namespace Assembler
{
    public class Program
    {
        public static string[] LoadAssemblyProgram()
        {
            return File.ReadAllText(@"C:\Users\brand\Documents\GitHub\Project6502\Project6502\Assembler\AssemblyProgram.asm").Split("\n");
        }

        static void Main(string[] args)
        {
            var asm = Assembler.Assemble(LoadAssemblyProgram());

            File.WriteAllBytes("AssembledProgramBytes.bin", Linker.Link(asm));
        }
    }
}