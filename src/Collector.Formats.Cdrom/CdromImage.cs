using System;
using System.Collections.Generic;

namespace Collector.Formats
{
    public class CdromImage
    {
        public readonly static string LongExtension = "cdrom";

        public readonly static string ShortExtension = "cd";

        public Guid Identifier { get; set; }

        public List<CdromSector> Sectors { get; } = new List<CdromSector>();
    }
}
