using System.Collections.Generic;

namespace Collector.DataManagement
{
    public class DumpMerger<T>
    {

        public IEnumerable<T> Collection { get; } = new List<T>();

        //public IEnumerable<List<DumpEntity>> Merge(params IEnumerable<T>[] sets)
        //{

        //}
    }
}
