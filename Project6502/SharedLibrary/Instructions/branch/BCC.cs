﻿namespace SharedLibrary.Instructions.Misc
{
    /// <summary>
    /// <para>Branch on Carry Clear</para>
    /// </summary>
    public class BCC : Instruction
    {
        public override string Name => "BCC";

        public override Dictionary<string, byte> AddressingPatternToOpcode => throw new NotImplementedException("Unused");
        private const byte opcode = 0x90;

        public BCC() { }
        public BCC(byte[] instructionData) => this.instructionData = instructionData;

        protected override byte[] GetInstructionData(int lineNumber, string asmInstruction, Instruction instruction)
        {
            if (!OpcodeToInstructionLength.ContainsKey(opcode))
            {
                OpcodeToInstructionLength.Add(opcode, 1);
            }

            return new byte[] { opcode, (byte)(LabelToLineNum[asmInstruction.Trim()] - lineNumber) };
        }
    }
}