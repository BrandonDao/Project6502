namespace SharedLibrary
{
    public class Status
    {
        public byte Value { get; set; }

        /// <summary>Negative Flag</summary>
        public bool N
        {
            get => (Value & 0b1000_0000) == 1;
            set => Value = value ? (byte)(Value | 0b1000_0000) : (byte)(Value ^ (Value & 0b1000_0000));
        }

        /// <summary>Overflow Flag</summary>
        public bool V
        {
            get => (Value & 0b0100_0000) == 1;
            set => Value = value ? (byte)(Value | 0b0100_0000) : (byte)(Value ^ (Value & 0b0100_0000));
        }

        /// <summary>Break Flag</summary>
        public bool B
        {
            get => (Value & 0b0010_0000) == 1;
            set => Value = value ? (byte)(Value | 0b0010_0000) : (byte)(Value ^ (Value & 0b0010_0000));
        }

        /// <summary>Decimal Flag</summary>
        public bool D
        {
            get => (Value & 0b0000_1000) == 1;
            set => Value = value ? (byte)(Value | 0b0000_1000) : (byte)(Value ^ (Value & 0b0000_1000));
        }

        /// <summary>Interrupt Disable Flag</summary>
        public bool I
        {
            get => (Value & 0b0000_0100) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0100) : (byte)(Value ^ (Value & 0b0000_0100));
        }

        /// <summary>Zero Flag</summary>
        public bool Z
        {
            get => (Value & 0b0000_0010) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0010) : (byte)(Value ^ (Value & 0b0000_0010));
        }

        /// <summary>Carry Flag</summary>
        public bool C
        {
            get => (Value & 0b0000_0001) == 1;
            set => Value = value ? (byte)(Value | 0b0000_0001) : (byte)(Value ^ (Value & 0b0000_0001));
        }


        public Status()
        {
            I = true;
        }
    }
}
