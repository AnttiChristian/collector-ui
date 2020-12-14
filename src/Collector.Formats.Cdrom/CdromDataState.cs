using System;

namespace Collector.Formats
{
    [Flags]
    public enum CdromDataState
    {
        Data = 1,

        Header = 2,

        SubChannel = 4,
    }
}