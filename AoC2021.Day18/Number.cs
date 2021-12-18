namespace AoC2021.Day18
{
    public abstract class Number
    {
        public SnailfishNumber? Parent { get; set; }
        public int Depth => Parent != null ? Parent.Depth + 1 : 0;

        public bool IsLeftChild => Parent != null && Parent.LeftChild.Equals(this);
        public bool IsRightChild => Parent != null && Parent.RightChild.Equals(this);

        public abstract long Magnitude { get; }

        public abstract Number Add(Number other);

        public void ReplaceWith(Number other)
        {
            if (Parent is null)
            {
                throw new InvalidOperationException("Tried to replace root element");
            }

            other.Parent = Parent;
            if (IsRightChild)
            {
                Parent.RightChild = other;
            }
            else
            {
                Parent.LeftChild = other;
            }
        }

        public IEnumerable<Number> EnumerateElements()
        {
            switch (this)
            {
                case SnailfishNumber s:
                    foreach (var n in s.LeftChild.EnumerateElements())
                    {
                        yield return n;
                    }

                    yield return this;
                    foreach (var n in s.RightChild.EnumerateElements())
                    {
                        yield return n;
                    }

                    yield break;

                default:
                    yield return this;
                    yield break;
            }
        }

        public abstract Number Clone();
    }
}
