using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle
{
    public class RectangleDTests
    {
        [Test]
        public void ShouldThrowThenWidthIsZero()
        {
            Action action = () => new RectangleD(0, 0, 0, 1);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldThrowThenHeightIsZero()
        {
            Action action = () => new RectangleD(0, 0, 1, 0);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldThrowThenRectangleIsIntersectNull()
        {
            var rec = new RectangleD(0, 0, 1, 1);

            Action action = () => rec.IsIntersect(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ShouldTrueThenRectanglesIsIntersect()
        {
            var rec1 = new RectangleD(0, 0, 2, 2);
            var rec2 = new RectangleD(1, 1, 2, 2);

            var isIntersect = rec1.IsIntersect(rec2);

            isIntersect.Should().BeTrue();
        }

        [Test]
        public void ShouldFalseThenRectanglesIsNotIntersect()
        {
            var rec1 = new RectangleD(0, 0, 1, 1);
            var rec2 = new RectangleD(2, 2, 1, 1);

            var isIntersect = rec1.IsIntersect(rec2);

            isIntersect.Should().BeFalse();
        }
    }
}