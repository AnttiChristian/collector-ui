using System.Collections.Generic;

namespace Collector.Formats.Floppy
{
    public class FloppyDiskTrack
    {
        public ushort TrackId { get; set; }

        public List<FloppyDiskSector> Sectors { get; } = new List<FloppyDiskSector>();
    }
}