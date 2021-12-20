using System.Text.RegularExpressions;

namespace AoC2021.Day19
{
    public class ScannerReader : IDisposable
    {
        private readonly TextReader _reader;

        public ScannerReader(TextReader reader)
        {
            _reader = reader;
        }

        static readonly Regex Matcher = new(@"^--- scanner (\d+) ---$");

        public IEnumerable<Scanner> ReadScanners()
        {
            for (var line = _reader.ReadLine(); line != null; line = _reader.ReadLine())
            {
                var match = Matcher.Match(line);
                if (!match.Success)
                {
                    throw new FormatException();
                }

                var id = int.Parse(match.Groups[1].Value);
                var beacons = new List<Beacon>();
                for (line = _reader.ReadLine(); !string.IsNullOrEmpty(line); line = _reader.ReadLine())
                {
                    var position = Vector.Parse(line);
                    var beacon = new Beacon(position);
                    beacons.Add(beacon);
                }

                yield return new Scanner(id, beacons);
            }
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
