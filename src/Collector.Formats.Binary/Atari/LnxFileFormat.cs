using System;

namespace Collector.Formats.Binary.Atari
{
    class LnxFileFormat
    {
        public string MagicText { get; set; } = string.Empty;                   // discard

        public ushort Bank0Size { get; set; }                                   // cartridge

        public ushort Bank1Size { get; set; }                                   // cartridge

        public ushort Version { get; set; }                                     // discard

        public string CartName { get; set; } = string.Empty;                    // discard

        public string Manufacturer { get; set; } = string.Empty;                // discard

        public byte Rotation { get; set; }                                      // configuration

        public byte Audin { get; set; }                                         // configuration?????

        public byte EepromType { get; set; }                                    // cartridge

        public byte[] Data { get; set; } = Array.Empty<byte>();                 // cartridge
    }
}
