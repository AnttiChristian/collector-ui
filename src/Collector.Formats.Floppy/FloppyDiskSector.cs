namespace Collector.Formats.Floppy
{
    public class FloppyDiskSector
    {
        public ushort SectorId { get; set; }

        public ushort SectorSize { get; set; }

        public FloppyDataEncoding Encoding { get; set; } = FloppyDataEncoding.FMEncoding;

        public byte[] Data { get; }

        public FloppyDiskSector(ushort sectorSize)
        {
            SectorSize = sectorSize;
            Data = new byte[sectorSize];
        }
    }
}