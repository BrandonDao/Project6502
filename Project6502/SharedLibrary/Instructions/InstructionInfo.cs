using SharedLibrary.AddressingModes;
using System.Diagnostics;

namespace SharedLibrary.Instructions
{
    [DebuggerDisplay("{InstructionType.Name} {AddressingMode.GetType().Name}")]
    public class InstructionInfo(byte opcode, IAddressingMode addressingMode)
    {
        public byte OpCode { get; } = opcode;
        public Type InstructionType { get; set; }
        public IAddressingMode AddressingMode { get; } = addressingMode;
    }
}