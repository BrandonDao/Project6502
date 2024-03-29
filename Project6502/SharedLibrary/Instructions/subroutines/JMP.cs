﻿using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;

namespace SharedLibrary.Instructions.Subroutines
{
    /// <summary>
    /// <para>Jump Indirect</para>
    /// </summary>
    public class JMP : Instruction
    {
        public override string Name => "JMP";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x4C, Absolute.Instance),
            [AbsoluteLabeled.Instance] = new InstructionInfo(0x4C, AbsoluteLabeled.Instance),
            [AbsoluteIndirect.Instance] = new InstructionInfo(0x6C, AbsoluteIndirect.Instance)
        };

        public JMP() { }
        public JMP(byte[] instructionData) => InstructionData = instructionData;

        public override void Execute(byte opCode, byte[] instructionData, byte[] memory, CPU CPU)
        {
            ushort jmpAddress = (ushort)((instructionData[1] << 8) | instructionData[0]);

            if (opCode == 0x6C)
            {
                jmpAddress = memory[jmpAddress];
            }

            CPU.RPC = jmpAddress;
        }
    }
}