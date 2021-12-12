using System.Text.RegularExpressions;

namespace AoC2021.Day12
{
    public class CaveMap
    {
        private Dictionary<string, Cave> _caves = new();

        static readonly Regex Matcher = new(@"(\w+)-(\w+)");

        public CaveMap(string[] lines)
        {
            foreach (var line in lines)
            {
                var match = Matcher.Match(line);
                if (!match.Success)
                {
                    throw new FormatException();
                }

                if (!_caves.ContainsKey(match.Groups[1].Value))
                {
                    _caves[match.Groups[1].Value] = new Cave(match.Groups[1].Value);
                }

                if (!_caves.ContainsKey(match.Groups[2].Value))
                {
                    _caves[match.Groups[2].Value] = new Cave(match.Groups[2].Value);
                }

                _caves[match.Groups[1].Value].Join(_caves[match.Groups[2].Value]);
            }
        }

        public IEnumerable<Route> GetRoutes(string from, string to, int revisits = 0)
        {
            var src = _caves[from];
            var dst = _caves[to];
            var routes = new Queue<Route>();
            routes.Enqueue(new Route(src));
            while (routes.Count > 0)
            {
                var route = routes.Dequeue();
                if (route.End.Equals(dst))
                {
                    yield return route;
                    continue;
                }

                foreach (var next in route.End.Neighbours)
                {
                    if (next.IsSmall && route.HasVisited(next) && (route.Revisits >= revisits || next.Equals(src)))
                    {
                        continue;
                    }

                    routes.Enqueue(new Route(route, next));
                }
            }
        }
    }
}
