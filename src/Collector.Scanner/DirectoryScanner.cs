using Collector.Database;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Readers;
using System.Collections.Generic;
using System.IO;

namespace Collector.Scanner
{
    public class DirectoryScanner
    {
        private void GetSevenZipData(string filename, DumpEntity dump)
        {
            var readerOptions = new ReaderOptions
            {
                LookForHeader = true
            };

            var archive = SevenZipArchive.Open(filename, readerOptions);
            foreach(SevenZipArchiveEntry entry in archive.Entries)
            {
                var blob = new BlobEntity
                {
                    Name = entry.Key,
                    Size = (ulong)entry.Size                    
                };

                blob.Hashes.Add("crc32", entry.Crc.ToString("x8"));

                dump.Blobs.Add(blob);
            }
        }


        private DumpEntity GetDump(string filename)
        {
            var extension = Path.GetExtension(filename);

            var dump = new DumpEntity {
                Name = Path.GetFileNameWithoutExtension(filename)
            };

            switch(extension)
            {
                // currently support only 7zip
                case ".7z":
                    GetSevenZipData(filename, dump);
                    break;
            }

            return dump;
        }

        public List<DumpEntity> ScanDirectory(string directory)
        {
            var result = new List<DumpEntity>();
            foreach(var filename in Directory.GetFiles(directory))
            {
                result.Add(GetDump(filename));
            }

            return result;
        }
    }
}
