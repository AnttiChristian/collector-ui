namespace Collector.Formats.Tapes.Atari
{
    public class CasChunk
    {
        public string Type { get; set; }

        public ushort Lenght { get; set; }

        public ushort Aux { get; set; }

        public byte[] Data { get; set; }
    }
}
