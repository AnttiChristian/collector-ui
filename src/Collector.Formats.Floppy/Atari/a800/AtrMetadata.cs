namespace Collector.Formats.Floppy.Atari.a800
{
    public class AtrMetadata : FloppyDiskMetadata
    {
        public ushort MagicBytes { get; set; }

        public uint DataSize { get; set; }          // only 24 bits => maximum size is 16MB

        public ushort SectorSize { get; set; }

        public uint Crc { get; set; }

        public uint Unused { get; set; }

        public byte Flags { get; set; }

        public AtrMetadata()
        {
            Source = "ATR Atari 800 floppy disk image";
        }
    }
}