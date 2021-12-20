namespace AoC2021.Day19
{
    public class Scanner
    {
        public int Id { get; set; }
        public List<Beacon> Beacons { get; set; }
        public Vector Position { get; }

        public Scanner(int id, IEnumerable<Beacon> beacons, Vector position = default)
        {
            Id = id;
            Beacons = beacons.ToList();
            Position = position;
        }

        public HashSet<double> GetDistances()
        {
            var distances = new HashSet<double>();
            for (int i = 0; i < Beacons.Count; i++)
            {
                for (int j = i + 1; j < Beacons.Count; j++)
                {
                    distances.Add(Beacons[i].Position.DistanceTo(Beacons[j].Position));
                }
            }

            return distances;
        }

        public Scanner Transform(Matrix transformer)
        {
            return Transform(p => transformer * p);
        }

        public Scanner Transform(Func<Vector, Vector> transform)
        {
            var beacons = Beacons.Select(beacon => new Beacon(transform(beacon.Position)));
            return new Scanner(Id, beacons, transform(Position));
        }
    }
}
