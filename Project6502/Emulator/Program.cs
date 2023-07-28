namespace Emulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emulator = new Emulator();

            byte[] asm = File.ReadAllBytes(@"..\..\..\..\Assembler\Assembly\AssembledProgramBytes.bin");
            emulator.LoadProgram(asm);


            while(true)
            {
                emulator.Emulate();
            }
        }
    }
}