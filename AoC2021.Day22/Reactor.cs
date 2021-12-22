namespace AoC2021.Day22
{
    public class Reactor
    {
        private List<Cuboid> _activatedCuboids = new();

        public long TotalCubes => _activatedCuboids.Sum(cuboid => cuboid.Size);

        public void ExecuteStep(RebootStep step)
        {
            var activatedCuboids = new List<Cuboid>();
            foreach (var cube in _activatedCuboids)
            {
                activatedCuboids.AddRange(cube.Except(step.Cuboid));
            }

            if (step.On)
            {
                activatedCuboids.Add(step.Cuboid);
            }

            _activatedCuboids = activatedCuboids;
        }

        public long GetActivatedCubes(Cuboid cuboid)
        {
            var total = 0L;
            foreach (var activated in _activatedCuboids)
            {
                total += activated.Intersect(cuboid)?.Size ?? 0;
            }

            return total;
        }
    }
}
