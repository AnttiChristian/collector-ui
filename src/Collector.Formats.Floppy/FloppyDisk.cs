using System.Collections.Generic;

namespace Collector.Formats.Floppy
{
    public class FloppyDisk
    {
        public FloppyDiskMetadata MetaData { get; set; } = new FloppyDiskMetadata { Source = "Unknown" };

        public List<FloppyDiskSide> Sides { get; } = new List<FloppyDiskSide>();
    }
}
