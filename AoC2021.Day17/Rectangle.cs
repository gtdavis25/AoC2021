namespace AoC2021.Day17
{
    public readonly struct Rectangle
    {
        public int X { get; init; }
        public int Y { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Vector point)
        {
            return X <= point.X && point.X <= X + Width && Y <= point.Y && point.Y <= Y + Height;
        }
    }
}
