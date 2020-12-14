using System.IO;

namespace Collector.Formats.Cdrom
{
    public static class ImageReaderFactory
    {
        public static IImageReader CreateReader(string filename)
        {
            return Path.GetExtension(filename) switch
            {
                ".iso" => new IsoImageReader(),
                ".bin" => new BinImageReader(),
                _ => new IsoImageReader()
            };
        }
    }
}
