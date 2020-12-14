using System.Collections.Generic;

namespace Collector.Database
{
    public record ReleaseEntity : Entity
    {
        public string Name { get; set; } = string.Empty;

        public string Region { get; set; } = "WRD";

        public List<DumpEntity> Dumps { get; } = new List<DumpEntity>();
    }
}
