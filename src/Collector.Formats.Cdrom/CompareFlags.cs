using System;

namespace Collector.Formats.Cdrom
{
    [Flags]
    public enum CompareFlags
    {
        SectorCount = 1,
        DataPart = 2,

    }
}