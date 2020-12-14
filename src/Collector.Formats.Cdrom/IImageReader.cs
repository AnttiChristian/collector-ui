namespace Collector.Formats.Cdrom
{
    public interface IImageReader
    {
        CdromImage ReadImage(string filename);
    }
}
