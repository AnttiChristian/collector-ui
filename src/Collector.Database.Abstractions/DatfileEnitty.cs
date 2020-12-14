// Collector.TT project

using System.Collections.Generic;

namespace Collector.Database
{
    public class DatfileEnitty
    {
        public string Name { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        // TODO: add weak date support

        public List<DumpEntity> Dumps { get; set; } = new List<DumpEntity>();
    }
}
