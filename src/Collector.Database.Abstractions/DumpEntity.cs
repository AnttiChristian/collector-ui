// Collector.TT project

using System.Collections.Generic;

namespace Collector.Database
{
    public record DumpEntity : Entity
    {
        public string Name { get; set; } = string.Empty;

        public List<BlobEntity> Blobs { get; set; } = new List<BlobEntity>();

        public List<DumpModifierEntity> Modifiers { get; set; } = new List<DumpModifierEntity>();
    }
}
