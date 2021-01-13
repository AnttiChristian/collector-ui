using System.IO;

namespace Collector.Formats.Umd
{
    public static class UmdWriter
    {
        public static void WriteIso(UmdDisc disc, string filename)
        {
            using var stream = new FileStream(filename, FileMode.Open, FileAccess.Write);
            using var writer = new BinaryWriter(stream);

            foreach (var sector in disc.Sectors)
            {

            }
        }

        public static void WriteUmd(UmdDisc disc, string filename)
        {
            using var stream = new FileStream(filename, FileMode.Open, FileAccess.Write);
            using var writer = new BinaryWriter(stream);

            foreach (var sector in disc.Sectors)
            {

            }
        }
    }
}
