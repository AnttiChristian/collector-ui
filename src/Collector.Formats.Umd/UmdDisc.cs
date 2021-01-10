using System.Collections.Generic;
using System.Linq;

namespace Collector.Formats.Umd
{
    public class UmdDisc
    {
        public const ushort SectorSize = 2048;

        public List<UmdDiscSector> Sectors { get; } = new List<UmdDiscSector>();

        public uint DiscSize => (uint)(Sectors.Count * SectorSize);

        public uint EncodedDiscSize => (uint)Sectors.Sum(s => s.Length);
    }
}
