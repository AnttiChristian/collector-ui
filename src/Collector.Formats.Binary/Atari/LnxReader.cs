using System;
using System.IO;
using System.Text;

namespace Collector.Formats.Binary.Atari
{
    class LnxReader : IDisposable
    {
        private const int _headerSize = 64;

        private readonly BinaryReader _reader;

        private readonly long _romSize;

        public LnxReader(string filename)
        {
            var fileInfo = new FileInfo(filename);
            _romSize = fileInfo.Length - _headerSize;
            var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            _reader = new BinaryReader(fileStream);
        }

        private void ParseHeader(byte[] buffer, LnxFileFormat lnxfile)
        {
            lnxfile.MagicText = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 0, 4).ToArray()));
            lnxfile.Bank0Size = (ushort)(buffer[4] + (256 * buffer[5]));
            lnxfile.Bank1Size = (ushort)(buffer[6] + (256 * buffer[7]));
            lnxfile.Version = (ushort)(buffer[8] + (256 * buffer[9]));
            lnxfile.CartName = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 10, 32).ToArray()));
            lnxfile.CartName = string.Concat(ASCIIEncoding.ASCII.GetChars(new Span<byte>(buffer, 42, 16).ToArray()));
            lnxfile.Rotation = buffer[58];
            lnxfile.Audin = buffer[59];
            lnxfile.EepromType = buffer[60];
        }

        public LnxFileFormat Read()
        {
            var buffer = new byte[_headerSize];
            _ = _reader.Read(buffer, 0, _headerSize);
            var lnxfile = new LnxFileFormat();

            ParseHeader(buffer, lnxfile);
            _ = _reader.Read(lnxfile.Data, 0, (int)_romSize);
            return lnxfile;
        }

        public void Dispose() => _reader.Close();
    }
}
