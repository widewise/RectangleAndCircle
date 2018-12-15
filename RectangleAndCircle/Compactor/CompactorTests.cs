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
        public void ShouldTrueThenAddRectangleWithWidthAndHeightLessDiameter()
        {
            var compactor = CompactorFactory.Create(10, 1);
            var rectangleParams = new RectangleParams(2, 3);

            var isAdded = compactor.AddRectangle(rectangleParams);

            isAdded.Should().BeTrue();
        }

        [Test]
        public void ShouldFalseThenAddRectangleWidthMoreDiameter()
        {
            var compactor = CompactorFactory.Create(2, 1);
            var rectangleParams = new RectangleParams(5, 3);

            Action action = () => compactor.AddRectangle(rectangleParams);

            action.Should().Throw<PythagorasException>();
        }

        [Test]
        public void ShouldFalseThenAddRectangleHeightMoreDiameter()
        {
            var compactor = CompactorFactory.Create(2, 1);
            var rectangleParams = new RectangleParams(3, 5);

            Action action = () => compactor.AddRectangle(rectangleParams);

            action.Should().Throw<PythagorasException>();
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