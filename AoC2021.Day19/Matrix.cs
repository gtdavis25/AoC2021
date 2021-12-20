using System.Text;

namespace AoC2021.Day19
{
    public class Matrix
    {
        private int[,] _cells;

        public int Width { get; }
        public int Height { get; }

        public int this[int x, int y] => _cells[x, y];

        public Matrix(int[,] cells)
        {
            Width = cells.GetLength(0);
            Height = cells.GetLength(1);
            _cells = cells;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Height)
            {
                throw new InvalidOperationException();
            }

            var height = m1.Height;
            var width = m2.Width;
            var cells = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int i = 0; i < m1.Width; i++)
                    {
                        cells[x, y] += m1[i, y] * m2[x, i];
                    }
                }
            }

            return new Matrix(cells);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append('[');
            for (int y = 0; y < Height; y++)
            {
                builder.Append('[');
                for (int x = 0; x < Width; x++)
                {
                    builder.Append(this[x, y]);
                    if (x + 1 < Width)
                    {
                        builder.Append(',');
                    }
                }

                builder.Append(']');
                if (y + 1 < Height)
                {
                    builder.Append(',');
                }
            }

            builder.Append(']');
            return builder.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Matrix other)
            {
                if (Width != other.Width || Height != other.Height)
                {
                    return false;
                }

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (this[x, y] != other[x, y])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
