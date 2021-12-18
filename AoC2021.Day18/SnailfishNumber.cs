namespace AoC2021.Day18
{
    public class SnailfishNumber : Number
    {
        public Number LeftChild { get; set; }
        public Number RightChild { get; set; }

        public override long Magnitude => 3 * LeftChild.Magnitude + 2 * RightChild.Magnitude;

        public RegularNumber LeftDescendant
        {
            get
            {
                switch (LeftChild)
                {
                    case RegularNumber n:
                        return n;

                    case SnailfishNumber s:
                        return s.LeftDescendant;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public RegularNumber RightDescendant
        {
            get
            {
                switch (RightChild)
                {
                    case RegularNumber n:
                        return n;

                    case SnailfishNumber s:
                        return s.RightDescendant;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public SnailfishNumber(Number leftChild, Number rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            LeftChild.Parent = this;
            RightChild.Parent = this;
        }

        public override string ToString()
        {
            return $"[{LeftChild},{RightChild}]";
        }

        public override Number Add(Number other)
        {
            if (other is SnailfishNumber n)
            {
                var result = new SnailfishNumber(this, n);
                while (result.Reduce()) ;
                return result;
            }

            throw new InvalidOperationException();
        }

        public bool Reduce()
        {
            foreach (var n in EnumerateElements())
            {
                if (n is SnailfishNumber s && s.Depth >= 4)
                {
                    s.Explode();
                    return true;
                }
            }

            foreach (var n in EnumerateElements())
            {
                if (n is RegularNumber r && r.Magnitude >= 10)
                {
                    r.Split();
                    return true;
                }
            }

            return false;
        }

        private void Explode()
        {
            var l = (RegularNumber)LeftChild;
            l.Previous?.ReplaceWith(l.Previous.Add(l));
            var r = (RegularNumber)RightChild;
            r.Next?.ReplaceWith(r.Next.Add(r));
            ReplaceWith(new RegularNumber(0));
        }

        public override Number Clone()
        {
            return new SnailfishNumber(LeftChild.Clone(), RightChild.Clone());
        }
    }
}
