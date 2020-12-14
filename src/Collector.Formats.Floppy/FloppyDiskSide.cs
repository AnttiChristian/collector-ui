using System.Collections.Generic;

namespace Collector.Formats.Floppy
{
    public class FloppyDiskSide
    {
        public char SideId { get; set; }

        public List<FloppyDiskTrack> Tracks { get; } = new List<FloppyDiskTrack>();
    }
}