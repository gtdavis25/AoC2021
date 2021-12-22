namespace AoC2021.Day22
{
    public readonly struct Cuboid
    {
        public Range X { get; init; }
        public Range Y { get; init; }
        public Range Z { get; init; }

        public long Size
        {
            get
            {
                var size = 1L;
                size *= X.Size;
                size *= Y.Size;
                size *= Z.Size;
                return size;
            }
        }

        public Cuboid(Range x, Range y, Range z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Cuboid? Intersect(Cuboid other)
        {
            var x = X.Intersect(other.X);
            var y = Y.Intersect(other.Y);
            var z = Z.Intersect(other.Z);
            if (!x.HasValue || !y.HasValue || !z.HasValue)
            {
                return null;
            }

            return new Cuboid(x.Value, y.Value, z.Value);
        }

        public IEnumerable<Cuboid> Except(Cuboid other)
        {
            var intersection = Intersect(other);
            if (intersection is null)
            {
                yield return this;
                yield break;
            }

            foreach (var range in X.Except(other.X))
            {
                yield return new Cuboid(range, Y, Z);
            }

            foreach (var range in Y.Except(other.Y))
            {
                yield return new Cuboid(intersection.Value.X, range, Z);
            }

            foreach (var range in Z.Except(other.Z))
            {
                yield return new Cuboid(intersection.Value.X, intersection.Value.Y, range);
            }
        }

        public override string ToString()
        {
            return $"x={X},y={Y},z={Z}";
        }
    }
}
