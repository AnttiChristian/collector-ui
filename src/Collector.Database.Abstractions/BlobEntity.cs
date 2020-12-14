using System.Collections.Generic;

namespace Collector.Database
{
    public record BlobEntity : Entity
    {
        public BlobStatus Status { get; set; } = BlobStatus.NoDump;

        public string Name { get; set; } = string.Empty;

        public ulong Size { get; set; }

        public Dictionary<string, string> Hashes { get; set; } = new Dictionary<string, string>();

        public string Flags { get; set; } = string.Empty;
    }
}
