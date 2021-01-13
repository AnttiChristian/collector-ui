using System;

namespace Collector.Formats
{
    public class Container
    {
        public Guid ContentType { get; set; }

        public uint HeaderSize { get; set; }

        /// <summary>
        /// Descriptor offset from the end of header.
        /// </summary>
        public ulong DescriptorOffset { get; set; }
    }
}
