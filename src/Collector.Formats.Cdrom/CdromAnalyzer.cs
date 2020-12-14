using System.Collections.Generic;
using System.IO;

namespace Collector.Formats.Cdrom
{
    public class CdromAnalyzer
    {
        private readonly Dictionary<string, CdromImage> _cdromImages = new Dictionary<string, CdromImage>();


        private IEnumerable<string> GetSupportedFiles(string foldername)
        {
            var result = new List<string>();
            result.AddRange(Directory.GetFiles(foldername, "*.iso"));
            result.AddRange(Directory.GetFiles(foldername, "*.bin"));
            return result;
        }

        public void AnalyzeFolder(string foldername)
        {
            foreach (var filename in GetSupportedFiles(foldername))
            {
                IImageReader reader = ImageReaderFactory.CreateReader(filename);
                CdromImage image = reader.ReadImage(filename);
                WriteImageInfo(image, filename + ".txt");
                _cdromImages.Add(filename, image);
            }

            var writer = new BinImageWriter();

            foreach (var filename in _cdromImages.Keys)
            {
                writer.WriteImage(_cdromImages[filename], filename + ".new");
            }
        }

        public IEnumerable<string> ValidateImage(CdromImage cdromImage)
        {
            var result = new List<string>();
            foreach (CdromSector sector in cdromImage.Sectors)
            {
                if (sector.Data[0x15] == (byte)CdromSectorMode.Mode1)
                {

                    var edc = ErrorCorrectionModel.CalculateEdc(sector.Data, 0, 0x810);
                    if (edc != sector.GetEdc())
                    {
                        result.Add("error");
                    }
                }
            }

            return result;
        }

        public void WriteImageInfo(CdromImage cdromImage, string filename)
        {
            try
            {
                using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                using var writer = new StreamWriter(stream);
                foreach (CdromSector sector in cdromImage.Sectors)
                {
                    writer.WriteLine($"{sector.GetAddress()}");
                }
            }
            catch
            {

            }
        }


    }
}
