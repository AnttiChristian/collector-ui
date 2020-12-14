using Collector.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collector.Formats.Cdrom
{
    public class CdromImageComparer
    {
        // TODO: expand comparer to use CompareFlags flags
        public async Task<List<CdromSectorComparisonResult>> Compare(CdromImage image1, CdromImage image2)
        {
            var result = new List<CdromSectorComparisonResult>();

            var sectorMax = Math.Max(image1.Sectors.Count, image2.Sectors.Count);

            for(var i =0; i < sectorMax; i++)
            {
                if (i >= image1.Sectors.Count)
                {
                    result.Add(new CdromSectorComparisonResult
                    {
                        SectorPhysicalAddress = i,
                        Message = "Sectors is missing in first image",
                        Equal = false
                    });

                    continue;
                }

                if (i >= image2.Sectors.Count)
                {
                    result.Add(new CdromSectorComparisonResult
                    {
                        SectorPhysicalAddress = i,
                        Message = "Sectors is missing in second image",
                        Equal = false
                    });

                    continue;
                }

                if (await BinaryComparer.Compare(image1.Sectors[i].Data, 0, image2.Sectors[i].Data, 0, CdromConstants.SectorDataSize))
                {
                    result.Add(new CdromSectorComparisonResult
                    {
                        SectorPhysicalAddress = i,
                        Message = "Sectors are equal",
                        Equal = true
                    });
                }
                else
                {
                    result.Add(new CdromSectorComparisonResult
                    {
                        SectorPhysicalAddress = i,
                        Message = "Sectors are not equal",
                        Equal = false
                    });
                }
            }

            return result;
        }
    }
}
