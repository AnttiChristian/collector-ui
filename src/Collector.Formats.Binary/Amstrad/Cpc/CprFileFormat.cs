using System.Linq;

namespace Collector.Formats.Binary.Amstrad.Cpc
{
    public class CprFileFormat
    {
        private Riff _content;

        private const int FixedChunkSize = 16384;

        public CprFileFormat(string filename)
        {
            using var reader = new RiffReader(filename);
            _content = reader.Read();
        }

        public byte[] ExtractRom()
        {
            int totalLength = _content.Chunks.Sum(c => c.Length);
            var result = new byte[totalLength];
            int address = 0;

            foreach (var chunk in _content.Chunks.OrderBy(c => c.ChunkId))
            {
                var length = chunk.Length > FixedChunkSize ? FixedChunkSize : chunk.Length;
                var fill = FixedChunkSize - length;
                for (var i = 0; i < length; i++)
                {
                    result[address] = chunk.Data[i];
                    address++;
                }

                for (var i = 0; i < fill; i++)
                {
                    result[address] = 0;
                    address++;
                }
            }

            return result;
        }
    }
}
