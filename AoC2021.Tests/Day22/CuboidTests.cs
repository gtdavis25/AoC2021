using System.Collections.Generic;
using System.Linq;
using AoC2021.Day22;
using Xunit;

namespace AoC2021.Tests
{
    public class CuboidTests
    {
        public static IEnumerable<object?[]> IntersectionTests => new object?[][]
        {
            new object?[]
            {
                new Cuboid(new Range(1, 2), new Range(1, 2), new Range(1, 2)),
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3)),
                new Cuboid(new Range(2, 2), new Range(2, 2), new Range(2, 2))
            },
            new object?[]
            {
                new Cuboid(new Range(1, 4), new Range(1, 4), new Range(1, 4)),
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3)),
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3))
            },
            new object?[]
            {
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3)),
                new Cuboid(new Range(1, 4), new Range(1, 4), new Range(1, 4)),
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3))
            },
            new object?[]
            {
                new Cuboid(new Range(1, 2), new Range(1, 2), new Range(1, 2)),
                new Cuboid(new Range(3, 4), new Range(3, 4), new Range(3, 4)),
                null
            }
        };

        [Theory]
        [MemberData(nameof(IntersectionTests))]
        public void Should_compute_intersection(Cuboid c1, Cuboid c2, Cuboid? expected)
        {
            Assert.Equal(expected, c1.Intersect(c2));
        }

        public static IEnumerable<object?[]> ExceptTests => new object?[][]
        {
            new object[]
            {
                new Cuboid(new Range(1, 2), new Range(1, 2), new Range(1, 2)),
                new Cuboid(new Range(3, 4), new Range(3, 4), new Range(3, 4)),
                new Cuboid[] { new Cuboid(new Range(1, 2), new Range(1, 2), new Range(1, 2)) }
            },
            new object[]
            {
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3)),
                new Cuboid(new Range(1, 4), new Range(1, 4), new Range(1, 4)),
                new Cuboid[] { }
            },
            new object[]
            {
                new Cuboid(new Range(1, 2), new Range(1, 2), new Range(1, 2)),
                new Cuboid(new Range(2, 3), new Range(2, 3), new Range(2, 3)),
                new Cuboid[]
                {
                    new Cuboid(new Range(1, 1), new Range(1, 2), new Range(1, 2)),
                    new Cuboid(new Range(2, 2), new Range(1, 1), new Range(1, 2)),
                    new Cuboid(new Range(2, 2), new Range(2, 2), new Range(1, 1))
                }
            },
            new object[]
            {
                new Cuboid(new Range(1, 3), new Range(1, 3), new Range(1, 3)),
                new Cuboid(new Range(2, 2), new Range(2, 2), new Range(2, 2)),
                new Cuboid[]
                {
                    new Cuboid(new Range(1, 1), new Range(1, 3), new Range(1, 3)),
                    new Cuboid(new Range(3, 3), new Range(1, 3), new Range(1, 3)),
                    new Cuboid(new Range(2, 2), new Range(1, 1), new Range(1, 3)),
                    new Cuboid(new Range(2, 2), new Range(3, 3), new Range(1, 3)),
                    new Cuboid(new Range(2, 2), new Range(2, 2), new Range(1, 1)),
                    new Cuboid(new Range(2, 2), new Range(2, 2), new Range(3, 3))
                }
            }
        };

        [Theory]
        [MemberData(nameof(ExceptTests))]
        public void Should_compute_difference(Cuboid c1, Cuboid c2, IEnumerable<Cuboid> expect)
        {
            Assert.Equal(expect, c1.Except(c2));
        }
    }
}
