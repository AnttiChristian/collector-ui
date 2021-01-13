namespace Collector.Formats.Umd
{
    public class UmdDiscSector
    {
        /// <summary>
        /// Sector index.
        /// </summary>
        public uint Id { get; set; }

        public UmdEncoding Encoding { get; set; } = UmdEncoding.None;

        /// <summary>
        /// Checksum of original data.
        /// </summary>
        public uint Crc32 { get; set; }

        /// <summary>
        /// Start position of the sector's first byte in file's data block.
        /// </summary>
        public uint StartPostiion { get; set; }

        /// <summary>
        /// Size of the encoded sector.
        /// </summary>
        public ushort Length { get; set; }

        /// <summary>
        /// Encoded sector data.
        /// </summary>
        public byte[]? Data { get; set; }
    }
}