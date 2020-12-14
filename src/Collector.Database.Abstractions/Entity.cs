// Collector.TT project

using System;

namespace Collector.Database
{
    public abstract record Entity
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = "unknown";
    }
}
