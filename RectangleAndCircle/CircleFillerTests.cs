using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle
{
    public class CircleFillerTests
    {
        private ICircleFiller _circleFiller;
        [SetUp]
        public void Setup()
        {
            var rectangleGenerator = new RandomRectangleGenerator();
            _circleFiller = new CircleFiller(rectangleGenerator);
        }

        [Test]
        public void ShouldThrowWhenRadiusIsZero()
        {
            Action action = () => _circleFiller.GetRectangles(0, 1);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldThrowWhenRadiusEqualMinRadius()
        {
            Action action = () => _circleFiller.GetRectangles(CircleFiller.MinRadius, 1);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldThrowWhenEpsilonMoreRadius()
        {
            var radius = 2;
            var epsilon = radius + 1;

            Action action = () => _circleFiller.GetRectangles(radius, epsilon);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldNoRectanglesWhenRadiusAndRectangleMinSizeRatioMoreSqrt2()
        {
            var rectangles = _circleFiller.GetRectangles(1, 2);
            rectangles.Should().BeEmpty();
        }

        [Test]
        public void ShouldOneRectangleWhenRectangleMinSizeAndRadiusRatioEqualSqrt2()
        {
            var radius = 1;
            var rectangleMinSize = 2;

            var rectangles = _circleFiller.GetRectangles(radius, rectangleMinSize);

            rectangles.Count().Should().Be(1);
            var rectangle = rectangles.First();
            var recY = (double) rectangleMinSize / 2;
            var recX = -recY;
            Compare(rectangle.X, recX);
            Compare(rectangle.Y, recY);
            Compare(rectangle.Height, rectangleMinSize);
            Compare(rectangle.Width, rectangleMinSize);
        }

        public void Compare(double value1, double value2)
        {
            var diff = Math.Abs(value1 - value2);
            diff.Should().BeLessThan(CircleFiller.Eps);
        }
    }
}