namespace Collector.Formats.Cdrom
{
    public static class ErrorCorrectionModel
    {
        private static readonly byte[] _eccFLookupTable = new byte[256];

        private static readonly byte[] _eccBLookupTable = new byte[256];

        private static readonly uint[] _edcLookupTable = new uint[256];

        static ErrorCorrectionModel()
        {
            uint i, j, edc;
            for (i = 0; i < 256; i++)
            {
                var xor = (uint)((i & 0x80) != 0 ? 0x11D : 0);
                j = (i << 1) ^ xor;
                _eccFLookupTable[i] = (byte)j;
                _eccBLookupTable[i ^ j] = (byte)i;
                edc = i;
                for (j = 0; j < 8; j++)
                {
                    edc = (edc >> 1) ^ ((edc & 1) != 0 ? 0xd8018001 : 0);
                }

                _edcLookupTable[i] = edc;
            }
        }

        public static uint CalculateEdc(byte[] data, uint offset, uint length)
        {
            uint edc = 0;
            for (var i = offset; i < length; i++)
            {
                edc = (edc >> 8) ^ (_edcLookupTable[(edc ^ data[i]) & 0xff]);
            }

            return edc;
        }


        private static void ComputeEcc(
            byte[] sectorData,
            uint readOffset,
            uint majorCount,
            uint minorCount,
            uint majorMultiplier,
            uint minorIncrement,
            uint writeOffset)
        {
            var size = majorCount * minorCount;
            for (var i = 0; i < majorCount; i++)
            {
                var index = (uint)(((i >> 1) * majorMultiplier) + (i & 1));
                byte eccA = 0;
                byte eccB = 0;

                for (var j = 0; j < minorCount; j++)
                {
                    var temp = sectorData[readOffset + index];
                    index += minorIncrement;
                    if (index > size) index -= size;
                    eccA ^= temp;
                    eccB ^= temp;
                    eccA = _eccFLookupTable[eccA];
                }

                eccA = _eccBLookupTable[_eccFLookupTable[eccA] ^ eccB];
                sectorData[writeOffset + i] = eccA;
                sectorData[writeOffset + i + majorCount] = (byte)(eccA ^ eccB);
            }
        }

        private static void ComputeSectorMode1Data(CdromSector sector)
        {
            const uint edcOffset = 0x810;
            var edc = CalculateEdc(sector.Data, 0, edcOffset);
            sector.Data[edcOffset + 0] = (byte)(edc & 0xff);
            sector.Data[edcOffset + 1] = (byte)((edc >> 8) & 0xff);
            sector.Data[edcOffset + 2] = (byte)((edc >> 16) & 0xff);
            sector.Data[edcOffset + 3] = (byte)((edc >> 24) & 0xff);

            for (var i = edcOffset + 4; i < edcOffset + 4 + 8; i++)
            {
                sector.Data[i] = 0;
            }

            ComputeEcc(sector.Data, 0x0c, 86, 24, 2, 86, 0x81c);
            ComputeEcc(sector.Data, 0x0c, 52, 43, 86, 88, 0x8c8);
        }


        public static void FixSector(CdromSector sector)
        {
            switch (sector.Mode)
            {
                case CdromSectorMode.Mode1:
                    ComputeSectorMode1Data(sector);
                    break;
            }
        }
    }
}
