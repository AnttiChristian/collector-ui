// Collector.TT project

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Collector.Data;

namespace Collector.Database
{
    public class Database
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Collection<ManufacturerEntity> Manufacturers { get; set; } = new Collection<ManufacturerEntity>();

        public Collection<HardwareEntity> Hardware { get; set; } = new Collection<HardwareEntity>();

        private List<T> DeserializeFromFile<T>(string path, string filename)
        {
            try
            {
                var data = File.ReadAllText(Path.Combine(path, filename));
                return JsonSerializer.Deserialize<List<T>>(data, _options) ?? new List<T>();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return new List<T>();
            }
        }

        public void Load(string path = "database")
        {
            Manufacturers = new Collection<ManufacturerEntity>(DeserializeFromFile<ManufacturerEntity>(path, "manufacturers.json"));
            Hardware = new Collection<HardwareEntity>(DeserializeFromFile<HardwareEntity>(path, "hardware.json"));
        }

        private void SaveData<T>(string path, string filename, List<T> value)
        {
            var data = JsonSerializer.Serialize<List<T>>(value);
            try
            {
                File.WriteAllText(Path.Combine(path, filename), data);
            }
            catch
            {

            }
        }

        public void Save(string path = "database")
        {
            SaveData<ManufacturerEntity>(path, "manufacturers.json", Manufacturers.Items ?? new List<ManufacturerEntity>());
            SaveData<HardwareEntity>(path, "hardware.json", Hardware.Items ?? new List<HardwareEntity>());
        }
    }
}
