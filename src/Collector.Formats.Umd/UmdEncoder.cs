using Collector.Utilities;
using Force.Crc32;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Formats.Umd
{
    public static class UmdEncoder
    {

        private static byte[] GetLinkData(uint physicalAddress)
        {
            var result = new byte[4];
            result[0] = (byte)(physicalAddress >> 24);
            result[1] = (byte)(physicalAddress >> 16);
            result[2] = (byte)(physicalAddress >> 8);
            result[3] = (byte)(physicalAddress);
            return result;
        }

        // TODO: optimize this method
        public static async Task Merge(UmdDisc masterDisc, UmdDisc disc)
        {
            var masterSectors = masterDisc.Sectors.Where(s => s.Encoding == UmdEncoding.None).OrderBy(s => s.Crc32).ToList();
            var sectors = disc.Sectors.Where(s => s.Encoding == UmdEncoding.None).OrderBy(s => s.Crc32).ToList();

            // if nothing to compare return
            if ((masterSectors == null) ||
                (sectors == null) ||
                (!masterSectors.Any()) ||
                (!sectors.Any())) return;

            int masterCursor = 0, cursor = 0;

            // sync cursors
            while ((masterCursor < masterSectors.Count) && (cursor < sectors.Count))
            {
                if (masterSectors[masterCursor].Crc32 == sectors[cursor].Crc32)
                {
                    int subCursor = 0;
                    while ((masterCursor + subCursor < masterSectors.Count) && (masterSectors[masterCursor].Crc32 == masterSectors[masterCursor + subCursor].Crc32))
                    {
                        if ((masterSectors[masterCursor + subCursor].Data != null) &&
                            (sectors[cursor].Data != null) &&
                            (await BinaryComparer.Compare(masterSectors[masterCursor + subCursor].Data, 0, sectors[cursor].Data, 0, UmdDisc.SectorSize)))
                        {
                            sectors[cursor].Encoding = UmdEncoding.ExternalLink;
                            sectors[cursor].Data = GetLinkData(masterSectors[masterCursor + subCursor].Id);
                            sectors[cursor].Length = 4;
                            sectors[cursor].Crc32 = Crc32Algorithm.Compute(sectors[cursor].Data, 0, 4);
                            break;
                        }
                        subCursor++;
                    }

                    cursor++;
                    continue;
                }

                if (masterSectors[masterCursor].Crc32 < sectors[cursor].Crc32)
                {
                    masterCursor++;
                    continue;
                }

                if (masterSectors[masterCursor].Crc32 > sectors[cursor].Crc32)
                {
                    cursor++;
                    continue;
                }
            }
        }

        public static async Task InternalMerge(UmdDisc disc)
        {
            IEnumerable<UmdDiscSector> sectors = disc.Sectors.Where(s => s.Encoding == UmdEncoding.None).ToList();
            uint pass = 1;
            while (sectors.Any())
            {
                System.Console.WriteLine($"Internal merge pass {pass}: {sectors.Count()} sectors.");
                sectors = await InternalMergePass(sectors);
                pass++;
            }
        }

        private static async Task<IEnumerable<UmdDiscSector>> InternalMergePass(IEnumerable<UmdDiscSector> sectors)
        {
            UmdDiscSector? baseSector = null;
            var result = new List<UmdDiscSector>();

            foreach (var sector in sectors.OrderBy(s => s.Crc32))
            {
                //System.Console.WriteLine(sector.Crc32);
                if ((baseSector == null) || (baseSector.Crc32 != sector.Crc32))
                {
                    baseSector = sector;
                    continue;
                }

                if ((baseSector.Crc32 == sector.Crc32) && (baseSector.Data != null) && (sector.Data != null))
                {
                    if (await BinaryComparer.Compare(baseSector.Data, 0, sector.Data, 0, UmdDisc.SectorSize))
                    {
                        sector.Encoding = UmdEncoding.InternalLink;
                        sector.Data = GetLinkData(baseSector.Id);
                        sector.Length = (ushort)sector.Data.Length;
                    }
                    else
                    {
                        result.Add(sector);
                    }
                }
            }

            return result;
        }
    }
}
