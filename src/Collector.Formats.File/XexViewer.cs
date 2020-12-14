using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xex_Viewer
{
    class XexFormat
    {
        public string Filename { get; set; }
        public List<XexBlock> Blocks { get; } = new List<XexBlock>();
    }

    class XexBlock
    {
        public bool HasSignature { get; }

        public ushort StartAddress { get; }

        public ushort Length { get; }

        public byte[] Data { get; set; }

        public XexBlock(bool hasSignature, ushort startAddress, ushort length)
        {
            this.StartAddress = startAddress;
            this.HasSignature = hasSignature;
            this.Length = length;
        }
    }

    interface FormatReader<T>
    {
        T Read(string filename, bool structureOnly = false);
    }

    abstract class BaseReader<TChunkType> : IDisposable where TChunkType : class
    {
        const int BufferSize = 65536;
        protected BinaryReader binaryReader;
        protected int position;
        public void Dispose()
        {
            this.binaryReader?.Close();
        }

        protected BinaryReader OpenFile(string filename)
        {
            try
            {
                var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                this.binaryReader = new BinaryReader(fileStream);
            }
            catch
            {
                this.binaryReader = null;
            }
            return this.binaryReader;
        }

        protected abstract TChunkType ConvertToChunk(byte[] data);

        protected virtual List<TChunkType> ReadData(BinaryReader reader)
        {
            //var data = new byte[length];
            //reader.Read(data, 0, length);
            var result = new List<TChunkType>();
            //TChunkType chunk = null;
            //while ((chunk = this.ConvertToChunk(data)) != null)
            //{
            //    result.Add(chunk);
            //}

            return result;
        }
    }

    class XexReader : BaseReader<XexBlock>, FormatReader<XexFormat>
    {
        public XexFormat Read(string filename, bool structureOnly = false)
        {
            var result = new XexFormat { Filename = filename };
            var streamReader = this.OpenFile(filename);
            this.ReadData(streamReader);

            return result;
        }

        protected override XexBlock ConvertToChunk(byte[] data)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            uint blockCount = 0;
            if (args.Length != 1)
            {
                Console.WriteLine("Provide file to analyze.");
            }
            try
            {
                var buffer = new byte[65536];
                var fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
                var binaryReader = new BinaryReader(fileStream);
                var read = true;
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    blockCount++;
                    binaryReader.Read(buffer, 0, 2);
                    Console.WriteLine($"BLOCK #ID{blockCount}");
                    var hasHeader = buffer[0] == 0xff && buffer[1] == 0xff;
                    Console.WriteLine($"Has header    : {hasHeader}");
                    if (hasHeader)
                    {
                        binaryReader.Read(buffer, 0, 2);
                    }
                    int startAddress = buffer[0] + 256 * buffer[1];
                    Console.WriteLine($"Start address : {startAddress}");
                    binaryReader.Read(buffer, 0, 2);
                    int endAddress = buffer[0] + 256 * buffer[1];
                    Console.WriteLine($"End address   : {endAddress}");
                    int blockSize = endAddress - startAddress + 1;
                    if (blockSize < 0)
                    {
                        blockSize = 0;
                        read = false;
                    }
                    Console.WriteLine($"Blocksize     : {blockSize}");
                    if (read)
                    {
                        binaryReader.Read(buffer, 0, blockSize);
                    }
                }
                binaryReader.Close();
            }
            catch(Exception exception)
            {
                Console.WriteLine($"IO error {exception.Message}.");
            }


            Console.ReadLine();
        }
    }
}
