using System;
using System.IO;
using System.Text;

namespace Collector.Formats
{
    public class RiffReader : IDisposable
    {
        private BinaryReader _reader;

        public RiffReader(string filename)
        {
            var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            _reader = new BinaryReader(fileStream);
        }

        private void ParseHeader(byte[] buffer, Riff riff)
        {
            riff.MagicBytes = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 0, 4).ToArray()));
            riff.DataSize = (int)buffer[4] + 256 * (int)buffer[5] + 65536 * (int)buffer[6] + 65536 * 256 * (int)buffer[7];
            riff.Format = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 8, 4).ToArray()));
        }

        private void ReadChunks(Riff riff)
        {
            var buffer = new byte[8];
            while (_reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                _reader.Read(buffer, 0, 8);
                var chunk = new RiffChunk();
                chunk.ChunkId = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 0, 4).ToArray()));
                chunk.Length = (int)buffer[4] + 256 * (int)buffer[5] + 65536 * (int)buffer[6] + 65536 * 256 * (int)buffer[7];
                chunk.Data = _reader.ReadBytes(chunk.Length);
                riff.Chunks.Add(chunk);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Riff Read()
        {
            var riff = new Riff();
            var buffer = new byte[12];
            _reader.Read(buffer, 0, 12);
            ParseHeader(buffer, riff);
            ReadChunks(riff);
            return riff;
        }

        public void Dispose()
        {
            _reader?.Close();
        }
    }
}
