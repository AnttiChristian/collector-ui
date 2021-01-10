using Collector.Formats.Umd;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UmdBuilder
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var disc1 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCET-00844-gow-beta1.iso", true);
            //var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCET-00179-beta2.iso", true);
            //var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCES-00109-beta3.iso", true);
            //var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCUS-98647.iso", true);
            //var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCET-00179-beta1.iso", true);
            //var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCUS-98671.iso", true);
            var disc2 = UmdReader.ReadFromIso("c:\\Temp\\umd\\UCUS-98719-gow-beta1.iso ", true);

            var stopWatch = new Stopwatch();
            Console.WriteLine($"Total sector: {disc1.Sectors.Count} - {disc1.DiscSize} - {disc1.EncodedDiscSize}");
            stopWatch.Start();
            await UmdEncoder.InternalMerge(disc1);
            stopWatch.Stop();
            Console.WriteLine($"Internal merge: {stopWatch.Elapsed}");
            stopWatch.Reset();
            Console.WriteLine($"Total sector: {disc1.Sectors.Count} - {disc1.DiscSize} - {disc1.EncodedDiscSize}");
            Console.WriteLine();
            Console.WriteLine($"Total sector: {disc2.Sectors.Count} - {disc2.DiscSize} - {disc2.EncodedDiscSize}");
            Console.WriteLine("External merge staretd:");
            stopWatch.Start();
            await UmdEncoder.Merge(disc1, disc2);
            stopWatch.Stop();
            Console.WriteLine($"Internal merge: {stopWatch.Elapsed}");
            Console.WriteLine($"Total sector: {disc2.Sectors.Count} - {disc2.DiscSize} - {disc2.EncodedDiscSize}");
            await UmdEncoder.InternalMerge(disc2);
            Console.WriteLine($"Total sector: {disc2.Sectors.Count} - {disc2.DiscSize} - {disc2.EncodedDiscSize}");

            //Console.WriteLine($"Total sector: {disc3.Sectors.Count}");
            //Console.WriteLine($"Total sector: {disc4.Sectors.Count}");
            //Console.WriteLine($"Total sector: {disc5.Sectors.Count}");
            //Console.WriteLine($"Total sector: {disc6.Sectors.Count}");
        }
    }
}
