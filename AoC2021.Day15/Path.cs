namespace AoC2021.Day15
{
    public class Path
    {
        public Location End { get; }
        public int TotalRisk { get; }

        public Path(Location start)
        {
            End = start;
        }

        public Path(Path pathSoFar, Location next)
        {
            TotalRisk = pathSoFar.TotalRisk + next.Risk;
            End = next;
        }
    }
}
