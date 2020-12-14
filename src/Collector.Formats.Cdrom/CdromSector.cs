using Collector.Formats.Cdrom;
using Force.Crc32;
using System;

namespace Collector.Formats
{
    public class CdromSector
    {
        public int PhysicalAddress { get; set; }

        public CdromSectorMode Mode { get; set; } = CdromSectorMode.Mode0;

        public CdromDataState State { get; set; } = CdromDataState.Data;

        public byte[] Data { get; } = new byte[CdromConstants.SectorDataSize + CdromConstants.SubChannelDataSize];

        public uint GetDataHash()
        {
            return Mode switch
            {
                CdromSectorMode.Mode1 => Crc32Algorithm.Compute(new Span<byte>(Data, 0x10, 2048).ToArray()),
                _ => Crc32Algorithm.Compute(Data)
            };
        }

        public uint GetAddress()
        {
            uint result = 0;
            for (var i = 0; i < 3; i++)
            {
                result = (result << 8) + Data[12 + i];
            }

            return result;
        }

        public uint GetEdc()
        {
            return Mode switch
            {
                CdromSectorMode.Mode1 => BitConverter.ToUInt32(Data, 0x810),
                _ => 0
            };
        }

        public CdromSector()
        {
            for (var i = 0; i < CdromConstants.SectorDataSize; i++)
            {
                Data[i] = 0;
            }
        }
    }
}