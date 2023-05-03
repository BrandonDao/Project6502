namespace SharedLibrary
{
    public class Status
    {
        public byte Value { get; set; }

        /// <summary>N Flag</summary>
        public bool Negative
        {
            get => (Value & 0b1000_0000) == 1;
            set => Value = value ? (byte)(Value | 0b1000_0000) : (byte)(Value ^ (Value & 0b1000_0000));
        }

        /// <summary>V Flag</summary>
        public bool Overflow
        {
            get => (Value & 0b0100_0000) == 1;
            set => Value = value ? (byte)(Value | 0b0100_0000) : (byte)(Value ^ (Value & 0b0100_0000));
        }

        /// <summary>B Flag</summary>
        public bool Break
        {
            get => (Value & 0b0010_0000) == 1;
            set => Value = value ? (byte)(Value | 0b0010_0000) : (byte)(Value ^ (Value & 0b0010_0000));
        }

        /// <summary>D Flag</summary>
        public bool Decimal
        {
            get => (Value & 0b0000_1000) == 1;
            set => Value = value ? (byte)(Value | 0b0000_1000) : (byte)(Value ^ (Value & 0b0000_1000));
        }

        /// <summary>I Flag</summary>
        public bool InterruptDisable
        {
            get => (Value & 0b0000_0100) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0100) : (byte)(Value ^ (Value & 0b0000_0100));
        }

        /// <summary>Z Flag</summary>
        public bool Zero
        {
            get => (Value & 0b0000_0010) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0010) : (byte)(Value ^ (Value & 0b0000_0010));
        }

        /// <summary>C Flag</summary>
        public bool Carry
        {
            get => (Value & 0b0000_0001) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0001) : (byte)(Value ^ (Value & 0b0000_0001));
        }
    }
}
