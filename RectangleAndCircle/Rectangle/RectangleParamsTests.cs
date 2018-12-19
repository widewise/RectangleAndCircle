using System;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle.Rectangle
{
    public class RectangleParamsTests
    {
        [Test]
        public void ShouldThrowThenWidthIsZero()
        {
            Action action = () => new RectangleParams(0, 1);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldThrowThenHieghtIsZero()
        {
            Action action = () => new RectangleParams(1, 0);
            action.Should().Throw<ArgumentException>();
        }
    }
}