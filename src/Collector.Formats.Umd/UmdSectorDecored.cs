using System;

namespace Collector.Formats.Umd
{
    public static class UmdSectorDecored
    {
        private static byte[]? DecodeInternalLink(UmdDiscSector sector, UmdDisc disc)
        {
            var sectorId = BitConverter.ToInt32(sector.Data);
            return disc.Sectors[sectorId].Data;
        }

        private static byte[]? DecodeExternalLink(UmdDiscSector sector, UmdDisc parentDisc)
        {
            var sectorId = BitConverter.ToInt32(sector.Data);
            return parentDisc.Sectors[sectorId].Data;
        }

        public static byte[] DecodeData(UmdDiscSector sector, UmdDisc disc, UmdDisc parentDisc)
        {
            return sector.Encoding switch
            {
                UmdEncoding.None => sector.Data ?? throw new InvalidOperationException("No data in sector"),
                UmdEncoding.InternalLink => DecodeInternalLink(sector, disc) ?? throw new InvalidOperationException("Internally linked sector has no data."),
                UmdEncoding.ExternalLink => DecodeExternalLink(sector, parentDisc) ?? throw new InvalidOperationException("Internally linked sector has no data."),
                _ => throw new InvalidOperationException("Unsupported encoding")
            };
        }
    }
}
