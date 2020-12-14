namespace Collector.Formats.Cdrom
{
    public class CdromSectorComparisonResult
    {
        public int SectorPhysicalAddress { get; set; }

        public bool Equal { get; set; } = false;

        public string Message { get; set; } = string.Empty;
    }
}
