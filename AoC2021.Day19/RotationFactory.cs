namespace AoC2021.Day19
{
    public class RotationFactory
    {
        static readonly Matrix Identity = new Matrix(new[,]
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        });

        static readonly Matrix X90 = new Matrix(new[,]
        {
            {1, 0, 0},
            {0, 0, -1},
            {0, 1, 0}
        });

        static readonly Matrix Y90 = new Matrix(new[,]
        {
            {0, 0, -1},
            {0, 1, 0},
            {1, 0, 0}
        });

        static readonly Matrix Z90 = new Matrix(new[,]
        {
            {0, -1, 0},
            {1, 0, 0},
            {0, 0, 1}
        });

        public IEnumerable<Matrix> GetRotations()
        {
            var m = Identity;
            var seen = new HashSet<Matrix>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (!seen.Contains(m))
                        {
                            seen.Add(m);
                            yield return m;
                        }

                        m = Z90 * m;
                    }

                    m = Y90 * m;
                }

                m = X90 * m;
            }
        }
    }
}
