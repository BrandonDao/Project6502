using SharedLibrary;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.Instructions;
using System.Reflection;

namespace Emulator
{
    public class Emulator
    {
        public CPU CPU { get; set; }

        /*
         * 64K bytes total
         *     32K RAM (0000 - 7FFF)
         *         0000 - 00FF  Zero Page
         *         0100 - 01FF  Stack
         *         0200 - 7FFF  General Purpose
         *     32K ROM (8000 - FFFF)
         *         8000 - FFF9  Program
         *         FFFA - FFFF  Reset Sequence Addresses
         */
        public static ushort ROMOffset => 0x8000;
        public static ushort StackOffset => 0x0100;
        public byte[] Memory { get; set; }

        private readonly Dictionary<byte, InstructionInfo> instructionInfoByOpCode;
        private readonly Dictionary<byte, Action<byte, byte[], byte[], CPU>> executorByOpcode;


        public Emulator()
        {
            CPU = new CPU();
            Memory = new byte[ushort.MaxValue];

            // Don't really want to use reflection here,
            // so hopefully this is just a temporary solution
            IEnumerable<Type> allInstructions = Assembly
                .GetAssembly(typeof(Instruction))!
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Instruction)));

            Instruction[] instantiatedInstructions = allInstructions
                .Where(type => type.GetConstructors().Length == 2)
                .Select(type => Activator.CreateInstance(type) as Instruction)
                .ToArray()!;

            instructionInfoByOpCode = new Dictionary<byte, InstructionInfo>();
            executorByOpcode = new Dictionary<byte, Action<byte, byte[], byte[], CPU>>();
            foreach (Instruction instruction in instantiatedInstructions)
            {
                foreach (var info in instruction.AddressingModeToInfo.Values)
                {
                    if (info.AddressingMode == AbsoluteLabeled.Instance || info.AddressingMode == RelativeLabeled.Instance) continue;

                    info.InstructionType = instruction.GetType();
                    instructionInfoByOpCode.Add(info.OpCode, info);
                    executorByOpcode.Add(info.OpCode, instruction.Execute);
                }
            }

            Reset();
        }

        public void Reset()
        {
            // checks 0xFFFA - 0xFFFB for the address of the reset sequence,
            // which does something to reset the computer

            CPU.RPC = ROMOffset;
            CPU.SP = 0xFF;
        }

        public void LoadProgram(byte[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                Memory[ROMOffset + i] = program[i];
            }
        }

        public void Emulate()
        {
            // fetch
            byte opCode = Memory[CPU.RPC];
            CPU.RPC++;

            if (!instructionInfoByOpCode.ContainsKey(opCode))
            {
                throw new InvalidOperationException($"Invalid assembly, unrecognized opcode: 0x{opCode:X2}!");
            }

            int length = instructionInfoByOpCode[opCode].AddressingMode.InstructionLength - 1;
            var data = new byte[length];

            for (int i = 0; i < length; i++)
            {
                data[i] += Memory[CPU.RPC];
                CPU.RPC++;
            }

            executorByOpcode[opCode].Invoke(opCode, data, Memory, CPU);
        }
    }
}
