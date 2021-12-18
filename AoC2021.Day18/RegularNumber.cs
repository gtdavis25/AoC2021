namespace AoC2021.Day18
{
    public class RegularNumber : Number
    {
        private long _value;
        public override long Magnitude => _value;

        public RegularNumber? Previous
        {
            get
            {
                Number prev = this;
                for (Number? current = Parent; current != null;)
                {
                    Number? next;
                    switch (current)
                    {
                        case RegularNumber r:
                            return r;

                        case SnailfishNumber s:
                            if (s.RightChild.Equals(prev))
                            {
                                next = s.LeftChild;
                            }
                            else if (s.LeftChild.Equals(prev))
                            {
                                next = s.Parent;
                            }
                            else
                            {
                                next = s.RightChild;
                            }

                            break;

                        default:
                            throw new InvalidOperationException();
                    }

                    prev = current;
                    current = next;
                }

                return null;
            }
        }

        public RegularNumber? Next
        {
            get
            {
                Number prev = this;
                for (Number? current = Parent; current != null;)
                {
                    Number? next;
                    switch (current)
                    {
                        case RegularNumber r:
                            return r;

                        case SnailfishNumber s:
                            if (s.RightChild.Equals(prev))
                            {
                                next = s.Parent;
                            }
                            else if (s.LeftChild.Equals(prev))
                            {
                                next = s.RightChild;
                            }
                            else
                            {
                                next = s.LeftChild;
                            }

                            break;

                        default:
                            throw new InvalidOperationException();
                    }

                    prev = current;
                    current = next;
                }

                return null;
            }
        }

        public RegularNumber(long value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return $"{Magnitude}";
        }

        public override Number Add(Number other)
        {
            if (other is RegularNumber n)
            {
                return new RegularNumber(Magnitude + n.Magnitude);
            }

            throw new InvalidOperationException("Tried to add numbers of mismatched types");
        }

        public void Split()
        {
            var left = new RegularNumber(Magnitude / 2);
            var right = new RegularNumber((Magnitude + 1) / 2);
            ReplaceWith(new SnailfishNumber(left, right));
        }

        public override Number Clone()
        {
            return new RegularNumber(_value);
        }
    }
}
