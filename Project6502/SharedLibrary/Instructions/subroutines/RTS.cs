﻿namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Return From Subroutine</para>
    /// </summary>
    public class RTS : Instruction
    {
        public override string Name => "RTS";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x60;

        public RTS() { }
        public RTS(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode };
        }
    }
}