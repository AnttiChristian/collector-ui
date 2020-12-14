using System.Collections.Generic;

namespace Collector.Database
{
    public class MergeResult
    {
        public List<DumpEntity> Removed { get; } = new List<DumpEntity>();
        public List<DumpEntity> Matched { get; } = new List<DumpEntity>();
        public List<DumpEntity> Added { get; } = new List<DumpEntity>();
    }
}
