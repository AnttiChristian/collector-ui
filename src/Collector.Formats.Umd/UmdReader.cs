using Force.Crc32;
using System.IO;

namespace Collector.Formats.Umd
{
    public static class UmdReader
    {
        public static UmdDisc? ReadFromIso(string filename, bool withData = false)
        {
            const ushort sectorSize = 2048;
            try
            {
                var result = new UmdDisc();
                var fileInfo = new FileInfo(filename);
                if (fileInfo.Length % sectorSize != 0) return null;

                var buffer = new byte[sectorSize];
                using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using var reader = new BinaryReader(stream);
                uint sectorCount = (uint)(fileInfo.Length / sectorSize);
                for (uint i = 0; i < sectorCount; i++)
                {
                    reader.Read(buffer, 0, sectorSize);

                    var sector = new UmdDiscSector
                    {
                        Id = i,
                        Crc32 = Crc32Algorithm.Compute(buffer, 0, sectorSize),
                        Length = sectorSize,
                        StartPostiion = (uint)(i * sectorSize)
                    };

                    if (withData)
                    {
                        sector.Data = buffer;
                        buffer = new byte[sectorSize];
                    }

                    result.Sectors.Add(sector);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
