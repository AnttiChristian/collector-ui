using System;
using System.IO;

namespace Collector.Utilities
{
    public class FileCutter
    {
        private const int BufferSize = 65536;
        public void CutFile(string originalFileName, string targetFileName, int start, int size)
        {
            try
            {
                var inputStream = new FileStream(originalFileName, FileMode.Open, FileAccess.Read);
                var binaryReader = new BinaryReader(inputStream);
                var outputStream = new FileStream(targetFileName, FileMode.Create, FileAccess.Write);
                var binaryWriter = new BinaryWriter(outputStream);
                byte[] buffer = new byte[BufferSize];
                int dataToWrite = size;
                int dataCount = 0;

                inputStream.Seek(start, SeekOrigin.Begin);
                while (dataToWrite > 0)
                {
                    dataCount = binaryReader.Read(buffer, 0, BufferSize);
                    binaryWriter.Write(buffer, 0, dataCount);
                    dataToWrite -= dataCount;
                    if (dataCount < BufferSize)
                    {
                        break;
                    }
                }

                binaryReader.Close();
                binaryWriter.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
