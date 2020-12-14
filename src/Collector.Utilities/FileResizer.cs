using System;
using System.IO;

namespace TheCollector.Utilities.Files
{
    public static class FileResizer
    {
        public const int BufferSize = 65536;

        public static void ResizeFile(string originalFileName, string targetFileName, int newSize, byte filler = 0)
        {
            byte[] buffer = new byte[BufferSize];
            int dataLength = 0;
            int position = 0;
            int countToWrite = newSize;
            try
            {
                var inputStream = new FileStream(originalFileName, FileMode.Open, FileAccess.Read);
                var binaryReader = new BinaryReader(inputStream);
                var outputStream = new FileStream(targetFileName, FileMode.Create, FileAccess.Write);
                var binaryWriter = new BinaryWriter(outputStream);

                while((dataLength = binaryReader.Read(buffer, 0, BufferSize)) > 0)
                {
                    position += dataLength;
                    countToWrite -= dataLength;
                    if (countToWrite > 0)
                    {
                        binaryWriter.Write(buffer, 0, dataLength);
                    }
                    else
                    {
                        binaryWriter.Write(buffer, 0, dataLength + countToWrite);
                        break;
                    }
                }

                binaryReader.Close();
                if (countToWrite > 0)
                {
                    for (int i = 0; i < BufferSize; i++)
                    {
                        buffer[i] = filler;
                    }

                    while(countToWrite > 0)
                    {
                        if (countToWrite > BufferSize)
                        {
                            binaryWriter.Write(buffer, 0, BufferSize);
                        }
                        else
                        {
                            binaryWriter.Write(buffer, 0, countToWrite);
                        }
                        countToWrite -= BufferSize;
                    }
                }

                binaryWriter.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
