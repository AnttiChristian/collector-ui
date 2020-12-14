using System;
using System.IO;

namespace Collector.Formats.Floppy.Atari.a800
{
    public class AtrReader
    {
        public const int SingleDensitySize = 1 * 40 * 18 * 128 + 16;
        public const int EnhancedDensitySize = 1 * 40 * 26 * 128 + 16;
        public const int DoubleDensitySize = 1 * 40 * 18 * 256 - 3 * 128 + 16;

        private void ReadMetadata(FloppyDisk floppyDisk, byte[] buffer)
        {
            var metaData = new AtrMetadata
            {
                MagicBytes = (ushort)(buffer[0] + 256 * buffer[1]),
                DataSize = (uint)((buffer[2] + 256 * buffer[3] + 65536 * buffer[6]) * 16),
                SectorSize = (ushort)(buffer[4] + 256 * buffer[5]),
                Crc = (uint)(buffer[8] + 256 * buffer[9] + 256 * 256 * buffer[10] + 256 * 256 * 256 * buffer[11]),
                Flags = buffer[15]
            };

            floppyDisk.MetaData = metaData;
        }

        private void SingleDensityBuilder(FloppyDisk floppyDisk, byte[] buffer)
        {
            for (var i = 0; i < 40; i++)
            {
                var track = new FloppyDiskTrack
                {
                    TrackId = (ushort)i
                };

                floppyDisk.Sides[0].Tracks.Add(track);

                for (var j = 0; j < 18; j++)
                {
                    var sector = new FloppyDiskSector(128);
                    sector.Encoding = FloppyDataEncoding.FMEncoding;
                    Buffer.BlockCopy(buffer, (i * 18 + j) * 128 + 16, sector.Data, 0, 128);

                    track.Sectors.Add(sector);
                }
            }
        }

        private void DoubleDensityBuilder(FloppyDisk floppyDisk, byte[] buffer)
        {
            var zeroTrack = new FloppyDiskTrack
            {
                TrackId = 0
            };

            floppyDisk.Sides[0].Tracks.Add(zeroTrack);

            // reading first track - first three sectors are 128 byte only regardless the density
            for (var i = 0; i < 3; i++)
            {
                var sector = new FloppyDiskSector(128)
                {
                    SectorId = (ushort)i
                };

                Buffer.BlockCopy(buffer, i * 128 + 16, sector.Data, 0, 128);
                zeroTrack.Sectors.Add(sector);
            }

            for (var i = 3; i < 18; i++)
            {
                var sector = new FloppyDiskSector(128)
                {
                    SectorId = (ushort)i
                };

                Buffer.BlockCopy(buffer, 3 * 128 + (i - 3) * 256 + 16, sector.Data, 0, 256);
                zeroTrack.Sectors.Add(sector);
            }

            for (var i = 1; i < 40; i++)
            {
                var track = new FloppyDiskTrack
                {
                    TrackId = (ushort)i
                };

                floppyDisk.Sides[0].Tracks.Add(track);

                for (var j = 0; j < 18; j++)
                {
                    var sector = new FloppyDiskSector(128);
                    sector.SectorId = (ushort)j;
                    sector.Encoding = FloppyDataEncoding.MFMEncoding;
                    Buffer.BlockCopy(buffer, (i * 18 + j) * 128 + 16, sector.Data, 0, 128);

                    track.Sectors.Add(sector);
                }
            }
        }

        private void EnhancedDensityBuilder(FloppyDisk floppyDisk, byte[] buffer)
        {
            for (var i = 0; i < 40; i++)
            {
                var track = new FloppyDiskTrack
                {
                    TrackId = (ushort)i
                };

                floppyDisk.Sides[0].Tracks.Add(track);

                for (var j = 0; j < 26; j++)
                {
                    var sector = new FloppyDiskSector(256);
                    sector.Encoding = FloppyDataEncoding.MFMEncoding;
                    Buffer.BlockCopy(buffer, (i * 26 + j) * 256 + 16, sector.Data, 0, 256);

                    track.Sectors.Add(sector);
                }
            }
        }

        private FloppyDisk Read(string filename)
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];

            var result = new FloppyDisk();
            using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(stream);
            reader.Read(buffer, 0, buffer.Length);

            ReadMetadata(result, buffer);

            if (buffer.Length == SingleDensitySize) SingleDensityBuilder(result, buffer);
            else if (buffer.Length == EnhancedDensitySize) EnhancedDensityBuilder(result, buffer);
            else if (buffer.Length == DoubleDensitySize) DoubleDensityBuilder(result, buffer);
            else throw new Exception("Unsupported size");

            return result;
        }
    }
}
