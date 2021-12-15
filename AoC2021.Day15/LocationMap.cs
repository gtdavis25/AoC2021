namespace AoC2021.Day15
{
    public class LocationMap
    {
        private Location[,] _locations;

        public int Width { get; }
        public int Height { get; }

        public Location this[int x, int y] => _locations[x, y];

        public LocationMap(int width, int height)
        {
            Width = width;
            Height = height;
            _locations = new Location[width, height];
        }

        public void AddLocation(int x, int y, int risk)
        {
            _locations[x, y] = new Location(x, y, risk);
            if (x > 0 && _locations[x - 1, y] != null)
            {
                _locations[x, y].Join(_locations[x - 1, y]);
            }

            if (y > 0 && _locations[x, y - 1] != null)
            {
                _locations[x, y].Join(_locations[x, y - 1]);
            }

            if (x + 1 < Width && _locations[x + 1, y] != null)
            {
                _locations[x, y].Join(_locations[x + 1, y]);
            }

            if (y + 1 < Height && _locations[x, y + 1] != null)
            {
                _locations[x, y].Join(_locations[x, y + 1]);
            }
        }
    }
}
