using System.Collections.Generic;

namespace Collector.Formats
{
    public class Riff
    {
        public string MagicBytes { get; set; } = "RIFF";

        public int DataSize { get; set; }

        public string Format { get; set; } = "    ";

        public List<RiffChunk> Chunks { get; } = new List<RiffChunk>();
    }
}
