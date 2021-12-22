namespace AoC2021.Day22
{
    public readonly struct Range
    {
        public int Min { get; init; }
        public int Max { get; init; }

        public int Size => (Max - Min + 1);

        public Range(int min, int max)
        {
            if (max < min)
            {
                throw new Exception();
            }

            Min = min;
            Max = max;
        }

        public bool Contains(int value)
        {
            return Min <= value && value <= Max;
        }

        public bool Contains(Range other)
        {
            return Min <= other.Min && other.Max <= Max;
        }

        public Range? Intersect(Range other)
        {
            if (Max < other.Min || other.Max < Min)
            {
                return null;
            }

            var min = Math.Max(Min, other.Min);
            var max = Math.Min(Max, other.Max);
            return new Range(min, max);
        }

        public IEnumerable<Range> Except(Range other)
        {
            if (other.Contains(this))
            {
                yield break;
            }

            var intersection = Intersect(other);
            if (intersection is null)
            {
                yield return this;
                yield break;
            }

            if (Min < intersection.Value.Min)
            {
                yield return new Range(Min, intersection.Value.Min - 1);
            }

            if (intersection.Value.Max < Max)
            {
                yield return new Range(intersection.Value.Max + 1, Max);
            }
        }

        public override string ToString()
        {
            return $"{Min}..{Max}";
        }
    }
}
