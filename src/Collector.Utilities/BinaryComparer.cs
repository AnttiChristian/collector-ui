using System.Threading.Tasks;

namespace Collector.Utilities
{
    public static class BinaryComparer
    {
        private static bool DetectWindow(byte[] buffer, int offset, int length) => (offset + length) <= buffer.Length;

        public static async Task<bool> Compare(byte[] first, int firstOffset, byte[] second, int secondOffset, int length)
        {
            return await Task<bool>.Run(() =>
            {
                if (!(
                    DetectWindow(first, firstOffset, length) &&
                    DetectWindow(first, secondOffset, length)
                ))
                {
                    return false;
                }

                for (var i = 0; i < length; i++)
                {
                    if (first[i + firstOffset] != second[i + secondOffset])
                    {
                        return false;
                    }
                }

                return true;
            });
        }
    }
}
