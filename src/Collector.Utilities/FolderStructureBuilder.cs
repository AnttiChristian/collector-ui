namespace Collector.Utilities
{
    public static class FolderStructureBuilder
    {
        //public static async Task CreateStructure(string targetLocation, bool useLongPaths = false)
        //{
        //    foreach (ManufacturerEntity manufacturer in Database.Manufacturer)
        //    {
        //        var relativePath = useLongPaths ? manufacturer.Name : manufacturer.Code;
        //        _ = await Task.Run(() => Directory.CreateDirectory(Path.Combine(targetLocation, relativePath)));
        //        foreach (HardwareEntity hardware in Database.Hardware.Where(h => h.ManufacturerId == manufacturer.Id))
        //        {
        //            var hardwarePath = useLongPaths ? hardware.Name : hardware.Code;
        //            _ = await Task.Run(() => Directory.CreateDirectory(Path.Combine(targetLocation, relativePath, hardwarePath)));
        //        }
        //    }
        //}
    }
}
