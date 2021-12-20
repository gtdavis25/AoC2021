namespace AoC2021.Day19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var scanners = new List<Scanner>();
            using (var reader = new ScannerReader(new StreamReader(args[0])))
            {
                scanners.AddRange(reader.ReadScanners());
            }

            var graph = BuildScannerGraph(scanners);
            graph.Nodes[0].TraverseGraph((node1, node2) =>
            {
                var s1 = scanners[node1.Id];
                var s2 = scanners[node2.Id];
                scanners[s2.Id] = RotateToFit(s1, s2);
            });

            var distinctCount = scanners
                .SelectMany(scanner => scanner.Beacons)
                .Select(beacon => beacon.Position)
                .Distinct()
                .Count();

            Console.WriteLine($"Part 1: {distinctCount}");
            var max = 0;
            for (int i = 0; i < scanners.Count; i++)
            {
                for (int j = i + 1; j < scanners.Count; j++)
                {
                    var distance = scanners[i].Position.ManhattanDistanceTo(scanners[j].Position);
                    if (distance > max)
                    {
                        max = distance;
                    }
                }
            }

            Console.WriteLine($"Part 2: {max}");
        }

        public static Graph BuildScannerGraph(List<Scanner> scanners)
        {
            var graph = new Graph();
            for (int i = 0; i < scanners.Count; i++)
            {
                for (int j = i + 1; j < scanners.Count; j++)
                {
                    var common = scanners[i]
                        .GetDistances()
                        .Intersect(scanners[j].GetDistances())
                        .Count();

                    if (common >= 66)
                    {
                        graph.GetNode(i).Join(graph.GetNode(j));
                    }
                }
            }

            return graph;
        }

        public static Dictionary<int, int> GetBeaconMapping(Scanner s1, Scanner s2)
        {
            var s1Distances = GetBeaconDistances(s1);
            var s2Distances = GetBeaconDistances(s2);
            var mapping = new Dictionary<int, int>();
            for (int i = 0; i < s1Distances.Count; i++)
            {
                for (int j = 0; j < s2Distances.Count; j++)
                {
                    var common = s1Distances[i].Intersect(s2Distances[j]).Count();
                    if (common >= 11)
                    {
                        mapping[i] = j;
                    }
                }
            }

            return mapping;
        }

        public static List<HashSet<double>> GetBeaconDistances(Scanner scanner)
        {
            var distances = new List<HashSet<double>>();
            for (int i = 0; i < scanner.Beacons.Count; i++)
            {
                distances.Add(new HashSet<double>());
                var b1 = scanner.Beacons[i];
                for (int j = 0; j < scanner.Beacons.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var b2 = scanner.Beacons[j];
                    distances[i].Add(b1.Position.DistanceTo(b2.Position));
                }
            }

            return distances;
        }

        public static Scanner RotateToFit(Scanner s1, Scanner s2)
        {
            var mapping = GetBeaconMapping(s1, s2);
            var rotations = new RotationFactory().GetRotations().ToList();
            foreach (var rotation in rotations)
            {
                var rotated = s2.Transform(rotation);
                var offsets = mapping
                    .Select(map => rotated.Beacons[map.Value].Position - s1.Beacons[map.Key].Position)
                    .ToList();

                if (offsets.Distinct().Count() > 1)
                {
                    continue;
                }

                var offset = offsets[0];
                return rotated.Transform(p => p - offset);
            }

            throw new Exception();
        }
    }
}
