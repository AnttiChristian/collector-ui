namespace Collector.Formats.Cdrom
{
    public static class CdromFormatConverter
    {
        public static void IsoToBin(string isofile, string binfile)
        {
            var isoReader = new IsoImageReader();
            CdromImage cdrom = isoReader.ReadImage(isofile);
            var binWriter = new BinImageWriter();
            binWriter.WriteImage(cdrom, binfile);
        }
        public static void BinToiso(string binfile, string isofile)
        {
            var binReader = new BinImageReader();
            CdromImage cdrom = binReader.ReadImage(binfile);
            var isoWriter = new IsoImageWriter();
            isoWriter.WriteImage(cdrom, isofile);
        }
    }
}
