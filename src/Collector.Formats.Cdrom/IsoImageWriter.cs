using System;
using System.IO;

namespace Collector.Formats.Cdrom
{
    public class IsoImageWriter
    {
        public void WriteImage(CdromImage cdromImage, string filename)
        {
            try
            {
                using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                using var writer = new BinaryWriter(stream);
                foreach (CdromSector sector in cdromImage.Sectors)
                {
                    writer.Write(sector.Data, CdromConstants.Mode1DataOffset, CdromConstants.Mode1DataSize);
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
