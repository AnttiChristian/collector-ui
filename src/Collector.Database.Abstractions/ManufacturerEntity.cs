// Collector.TT project

namespace Collector.Database
{
    public record ManufacturerEntity : Entity
    {
        public string Name { get; set; } = string.Empty;

        public override string ToString() => $"{Name} ({Code})";
    }
}
