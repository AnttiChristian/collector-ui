// Collector.TT project

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Collector.Database;

namespace Collector.DataManagement
{
    public class DatFilesManager
    {
        private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public List<DatfileEnitty> Load(ManufacturerEntity manufacturer, HardwareEntity hardware, string repositoryPath)
        {
            var path = Path.Combine(repositoryPath, manufacturer.Code, hardware.Code);

            List<DatfileEnitty>? result = new List<DatfileEnitty>();
            if (!Directory.Exists(path)) return result;

            foreach (string filename in Directory.GetFiles(path, "*.json"))
            {
                var datfile = JsonSerializer.Deserialize<DatfileEnitty>(File.ReadAllText(filename), _jsonOptions);
                if (datfile is not null)
                {
                    result.Add(datfile);
                }
            }

            return result;
        }
    }
}
