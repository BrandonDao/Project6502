using SharedLibrary.AddressingModes;
using System.Diagnostics;

namespace SharedLibrary.Instructions
{
    [DebuggerDisplay("{InstructionType.Name} {AddressingMode.GetType().Name}")]
    public class InstructionInfo
    {
        public byte OpCode { get; }
        public Type InstructionType { get; set; }
        public IAddressingMode AddressingMode { get; }

        public InstructionInfo(byte opcode, IAddressingMode addressingMode)
        {
            OpCode = opcode;
            AddressingMode = addressingMode;
        }
    }
}