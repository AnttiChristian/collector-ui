namespace Collector.Formats.Cdrom
{
    public class CdromSectorAddress
    {
        private const uint _defaultCorrection = 150;

        public byte Minute { get; set; }

        public byte Second { get; set; }

        public byte Frame { get; set; }

        public uint Address
        {
            get => (uint)((Minute * 65536) + (Second * 256) + Frame);
            set => Calculate(value, _defaultCorrection);
        }

        public CdromSectorAddress(uint physical, uint correction = _defaultCorrection)
        {
            Calculate(physical, correction);
        }

        private void Calculate(uint physical, uint correction)
        {
            // calculate address
            var realAddress = physical + correction;
            Frame = (byte)(realAddress % 75);
            Second = (byte)(realAddress / 75 % 60);
            Minute = (byte)(realAddress / 75 / 60);

            // bcd encoding
            Frame = (byte)((16 * (Frame / 10)) + (Frame % 10));
            Second = (byte)((16 * (Second / 10)) + (Second % 10));
            Minute = (byte)((16 * (Minute / 10)) + (Minute % 10));
        }
    }
}
