namespace Collector.Database
{
    public record DumpModifierEntity
    {
        public string ModType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}