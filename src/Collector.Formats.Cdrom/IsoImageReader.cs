using System;
using System.IO;

namespace Collector.Formats.Cdrom
{
    internal class IsoImageReader : IImageReader
    {
        private void FixSectorData(CdromSector sector)
        {
            for (var i = 1; i < 11; i++)
            {
                sector.Data[i] = 0xff;
            }

            var sectorAddress  = new CdromSectorAddress((uint)sector.PhysicalAddress);

            sector.Data[0x0c] = sectorAddress.Minute;
            sector.Data[0x0d] = sectorAddress.Second;
            sector.Data[0x0e] = sectorAddress.Frame;
            sector.Data[0x0f] = (byte)CdromSectorMode.Mode1;

            ErrorCorrectionModel.FixSector(sector);
        }

        public CdromImage ReadImage(string filename)
        {
            byte[] buffer;
            try
            {
                var fileinfo = new FileInfo(filename);
                if (fileinfo.Length % 2048 != 0) throw new IOException($"File size of {filename} does not match.");

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
            for (var i = 0; i < buffer.Length / 2048; i++)
            {
                var sector = new CdromSector
                {
                    PhysicalAddress = i,
                    Mode = CdromSectorMode.Mode1
                };

                Buffer.BlockCopy(buffer, i * 2048, sector.Data, 0x10, 2048);
                FixSectorData(sector);
                cdrom.Sectors.Add(sector);
            }

            return cdrom;
        }
    }
}