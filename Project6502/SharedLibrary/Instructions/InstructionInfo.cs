using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions
{
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