namespace Collector.Formats.Umd
{
    public static class UmdDiscExtensions
    {
        public static void RecalculatePositions(this UmdDisc disc)
        {
            uint currentPostition = 0;
            for (int i = 0; i < disc.Sectors.Count; i++)
            {
                disc.Sectors[i].StartPostiion = currentPostition;
                currentPostition += disc.Sectors[i].Length;
            }
        }
    }
}
