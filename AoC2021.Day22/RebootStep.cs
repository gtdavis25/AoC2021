using System.Text.RegularExpressions;

namespace AoC2021.Day22
{
    public class RebootStep
    {
        public bool On { get; }
        public Cuboid Cuboid { get; }

        public RebootStep(bool on, Cuboid cuboid)
        {
            On = on;
            Cuboid = cuboid;
        }

        const string Pattern = @"^(on|off) x=(-?\d+)\.\.(-?\d+),y=(-?\d+)\.\.(-?\d+),z=(-?\d+)..(-?\d+)$";

        static readonly Regex Matcher = new(Pattern);

        public static RebootStep Parse(string line)
        {
            var match = Matcher.Match(line);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var on = match.Groups[1].Value == "on";
            var minX = int.Parse(match.Groups[2].Value);
            var maxX = int.Parse(match.Groups[3].Value);
            var minY = int.Parse(match.Groups[4].Value);
            var maxY = int.Parse(match.Groups[5].Value);
            var minZ = int.Parse(match.Groups[6].Value);
            var maxZ = int.Parse(match.Groups[7].Value);
            var xRange = new Range(minX, maxX);
            var yRange = new Range(minY, maxY);
            var zRange = new Range(minZ, maxZ);
            var cuboid = new Cuboid(xRange, yRange, zRange);
            return new RebootStep(on, cuboid);
        }
    }
}
