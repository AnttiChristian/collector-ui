using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomCollector.Formats.Atari.Xex
{
    public class XexBlock
    {
        private byte[] data;

        public bool HasHeader
        {
            get
            {
                return (this.data[0] & this.data[1] & 0xff) == 0xff;
            }
        }

        public ushort 

        public XexBlock(ushort size)
        {
            this.data = new byte[size];
        }
    }
}
