﻿using SharedLibrary.AddressingModes;

namespace SharedLibrary.Instructions
{
    public class InstructionInfo
    {
        public byte Opcode { get; }
        public IAddressingMode AddressingMode { get; }

        public InstructionInfo(byte opcode, IAddressingMode addressingMode)
        {
            Opcode = opcode;
            AddressingMode = addressingMode;
        }
    }
}