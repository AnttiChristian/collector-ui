namespace Collector.Formats.Tapes.Atari
{
    class Chunk
    {
        public const string FujiChunkName = "FUJI";
        public const string BaudChunkName = "baud";
        public const string DataChunkName = "data";
        public const string Fsk_ChunkName = "fsk ";
        public const string PwmsChunkName = "pwms";
        public const string PwmcChunkName = "pwmc";
        public const string PwmlChunkName = "pwml";
        public const string PwmdChunkName = "pwmd";

        /// <summary>
        /// 4-letter string.
        /// </summary>
        public string Name { get; set; } = FujiChunkName;

        /// <summary>
        /// Chunk length (not including header)
        /// </summary>
        public ushort Length { get; set; }

        /// <summary>
        /// Contents depend on chunk type.
        /// </summary>
        public ushort Aux { get; set; }

        /// <summary>
        /// Chunk data
        /// </summary>
        public byte[] Data { get; set; }
    }
}
