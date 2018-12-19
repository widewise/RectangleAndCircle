using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.Compactor
{
    public class CompactorTests
    {
        [Test]
        public void ShouldThrowWhenAddAttemptCountEqualZero()
        {
            Action action = () => CompactorFactory.Create(3, 0);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldCompartRectangleOnCircleThenAddRectangleWithMaxWidthAndHeight()
        {
            var radius = 5;
            var addAttemptCount = 1;
            var width = 6;
            var height = 8;
            var compactor = CompactorFactory.Create(radius, addAttemptCount);
            var rectangleParams = new RectangleParams(width, height);

            var isAdded = compactor.AddRectangle(rectangleParams);

            isAdded.Should().BeTrue();
            compactor.Rectangles.Should().NotBeEmpty();
            compactor.Rectangles.Count().Should().Be(1);
            var rec = compactor.Rectangles.First();

            rec.X.Should().Be(- width / 2);
            rec.Y.Should().Be(height / 2);
            rec.Width.Should().Be(width);
            rec.Height.Should().Be(height);
        }
    }
}