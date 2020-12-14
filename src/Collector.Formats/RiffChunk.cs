using System;

namespace Collector.Formats
{
    public class RiffChunk
    {
        public string ChunkId { get; set; } = "Unkn";

        public int Length { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}