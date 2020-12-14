using System;

namespace Collector.Formats.Binary.Atari
{
    public class A78FileFormat
    {
        public byte Version { get; set; }

        public string MagicText { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int DataSize { get; set; }

        public short CartType { get; set; }

        public byte Controller1Type { get; set; }

        public byte Controller2Type { get; set; }

        public byte TVType { get; set; }

        public byte SaveDevice { get; set; }

        public byte ExpansionModule { get; set; }

        public string ClosingText { get; set; } = string.Empty;

        public byte[] Data { get; set; } = Array.Empty<byte>();

        public byte[] ExtractRom() => Data;
    }
}
