﻿using SharedLibrary.AddressingModes;
using SharedLibrary.AddressingModes.Absolute;
using SharedLibrary.AddressingModes.Misc;
using SharedLibrary.AddressingModes.ZeroPage;

namespace SharedLibrary.Instructions.ALU.ShiftAndRotate
{
    /// <summary>
    /// <para>Rotate Left</para>
    /// <para>Shifts right 1 bit with bit 0 stored in the carry and the carry stored in bit 7</para>
    /// <para>Flags:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>N (Negative)</term>
    ///         <description>Set to the input carry</description>
    ///     </item>
    ///     <item>
    ///         <term>Z (Zero)</term>
    ///         <description>Set if the result of the operation is 0</description>
    ///     </item>
    ///     <item>
    ///         <term>C (Carry)</term>
    ///         <description>Set to bit 0 of the input</description>
    ///     </item>
    /// </list>
    /// </summary>
    public class ROR : Instruction
    {
        public override string Name => "ROR";

        public override Dictionary<IAddressingMode, InstructionInfo> AddressingModeToInfo => new()
        {
            [Absolute.Instance] = new InstructionInfo(0x6E, Absolute.Instance),
            [AbsoluteX.Instance] = new InstructionInfo(0x7E, AbsoluteX.Instance),
            [Implied.Instance] = new InstructionInfo(0x6A, Implied.Instance),
            [ZeroPage.Instance] = new InstructionInfo(0x66, ZeroPage.Instance),
            [ZeroPageX.Instance] = new InstructionInfo(0x76, ZeroPageX.Instance)
        };

        public ROR() { }
        public ROR(byte[] instructionData) => this.instructionData = instructionData;
    }
}