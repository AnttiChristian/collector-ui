using System;
using System.IO;

namespace Collector.Formats.Cdrom
{
    public class BinImageWriter
    {
        public void WriteImage(CdromImage cdromImage, string filename)
        {
            try
            {
                using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                using var writer = new BinaryWriter(stream);
                foreach (CdromSector sector in cdromImage.Sectors)
                {
                    writer.Write(sector.Data, 0, CdromConstants.SectorDataSize);
                }
            }
            catch (Exception exception)
            {
                // TODO logging
                Console.WriteLine(exception.Message);
            }
        }
    }
}
