using System;
using System.IO;
using System.Text;

namespace Collector.Formats.Binary.Atari
{
    class A78Reader : IDisposable
    {
        private readonly BinaryReader _reader;

        public A78Reader(string filename)
        {
            var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            _reader = new BinaryReader(fileStream);
        }

        private void ParseHeader(byte[] buffer, A78FileFormat a78file)
        {
            a78file.Version = buffer[0];
            a78file.MagicText = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 1, 16).ToArray()));
            a78file.Title = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 17, 32).ToArray()));
            a78file.DataSize = (int)buffer[49] + (256 * (int)buffer[50]) + (65536 * (int)buffer[51]) + (65536 * 256 * (int)buffer[52]);
            a78file.CartType = (short)(buffer[53] + (256 * buffer[54]));
            a78file.Controller1Type = buffer[55];
            a78file.Controller2Type = buffer[56];
            a78file.TVType = buffer[57];
            a78file.SaveDevice = buffer[58];
            a78file.ExpansionModule = buffer[63];
            a78file.ClosingText = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 100, 28).ToArray()));
        }

        public A78FileFormat Read()
        {
            var buffer = new byte[128];
            _ = _reader.Read(buffer, 0, 128);
            var a78file = new A78FileFormat();

            ParseHeader(buffer, a78file);
            _ = _reader.Read(a78file.Data, 0, a78file.DataSize);
            return a78file;
        }

        public void Dispose() => _reader.Close();
    }
}
