// Collector.TT project

using System;
using System.IO;

namespace Collector.Formats.Cdrom
{
    public class BinImageReader : IImageReader
    {
        public CdromImage ReadImage(string filename)
        {
            byte[] buffer;
            FileInfo fileinfo;
            try
            {
                fileinfo = new FileInfo(filename);
                if (fileinfo.Length % 2352 != 0) throw new IOException($"File size of {filename} does not match.");
            }
            catch (Exception exception)
            {
                throw new IOException($"Unable to read file {filename}", exception);
            }

            try
            {
                buffer = new byte[fileinfo.Length];
                using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using var reader = new BinaryReader(stream);
                if (reader.Read(buffer, 0, (int)fileinfo.Length) != fileinfo.Length) throw new IOException($"Unable to read whole {filename} file."); ;
            }
            catch (Exception exception)
            {
                throw new IOException($"Unable to read file {filename}", exception);
            }

            var cdrom = new CdromImage();
            for (var i = 0; i < buffer.Length / 2352; i++)
            {
                var sector = new CdromSector
                {
                    PhysicalAddress = i,
                    Mode = CdromSectorMode.Mode1
                };

                Buffer.BlockCopy(buffer, i * 2352, sector.Data, 0, 2352);
                cdrom.Sectors.Add(sector);
            }

            return cdrom;
        }
    }
}
