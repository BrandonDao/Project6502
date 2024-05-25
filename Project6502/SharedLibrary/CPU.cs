namespace SharedLibrary
{
    public class CPU()
    {
        /// <summary>Accumulator</summary>
        public byte RA { get; set; }

        /// <summary>X Register</summary>
        public byte RX { get; set; }

        /// <summary>Y Register</summary>
        public byte RY { get; set; }

        /// <summary>Stack Pointer</summary>
        public byte SP { get; set; }

        /// <summary>Status</summary>
        public Status RP { get; set; } = new Status();

        /// <summary>Program Counter</summary>
        public ushort RPC { get; set; }
    }
}