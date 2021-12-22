using System.Collections.Generic;
using AoC2021.Day22;
using Xunit;

namespace AoC2021.Tests
{
    public class RangeTests
    {
        public static IEnumerable<object?[]> IntersectionTests => new[]
        {
            new object?[] { new Range(1, 4), new Range(2, 3), new Range(2, 3) },
            new object?[] { new Range(2, 3), new Range(1, 4), new Range(2, 3) },
            new object?[] { new Range(1, 2), new Range(3, 4), null },
            new object?[] { new Range(3, 4), new Range(1, 2), null },
            new object?[] { new Range(1, 3), new Range(2, 4), new Range(2, 3) },
            new object?[] { new Range(2, 4), new Range(1, 3), new Range(2, 3) },
        };

        [Theory]
        [MemberData(nameof(IntersectionTests))]
        public void Should_compute_range_intersection(Range r1, Range r2, Range? expect)
        {
            Assert.Equal(expect, r1.Intersect(r2));
        }

        public static IEnumerable<object[]> ExceptTests => new[]
        {
            new object[]
            {
                new Range(1, 2),
                new Range(3, 4),
                new Range[] { new Range(1, 2) }
            },
            new object[]
            {
                new Range(1, 4),
                new Range(2, 3),
                new Range[] { new Range(1, 1), new Range(4, 4) }
            },
            new object[]
            {
                new Range(2, 3),
                new Range(1, 4),
                new Range[] { }
            },
            new object[]
            {
                new Range(1, 3),
                new Range(2, 4),
                new Range[] { new Range(1, 1) }
            },
            new object[]
            {
                new Range(2, 4),
                new Range(1, 3),
                new Range[] { new Range(4, 4) }
            }
        };

        [Theory]
        [MemberData(nameof(ExceptTests))]
        public void Should_compute_range_difference(Range r1, Range r2, IEnumerable<Range> expect)
        {
            Assert.Equal(expect, r1.Except(r2));
        }
    }
}
