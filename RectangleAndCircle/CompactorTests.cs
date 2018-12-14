using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle
{
    public class CompactorTests
    {
        private IInCircleChecker _inCircleChecker;
        [SetUp]
        public void Setup()
        {
            _inCircleChecker = new InCircleChecker();
        }
        [Test]
        public void ShouldTrueThenAddRectangleWithWidthAndHeightLessDiameter()
        {
            var compactor = new Compactor(10, _inCircleChecker);
            var rectangleParams = new RectangleParams(2, 3);

            var isAdded = compactor.AddRectangle(rectangleParams);

            isAdded.Should().BeTrue();
        }

        [Test]
        public void ShouldFalseThenAddRectangleWidthMoreDiameter()
        {
            var compactor = new Compactor(2, _inCircleChecker);
            var rectangleParams = new RectangleParams(5, 3);

            Action action = () => compactor.AddRectangle(rectangleParams);

            action.Should().Throw<PythagorasException>();
        }

        [Test]
        public void ShouldFalseThenAddRectangleHeightMoreDiameter()
        {
            var compactor = new Compactor(2, _inCircleChecker);
            var rectangleParams = new RectangleParams(3, 5);

            Action action = () => compactor.AddRectangle(rectangleParams);

            action.Should().Throw<PythagorasException>();
        }

        [Test]
        public void ShouldCompartRectangleOnCircleThenAddRectangleWithMaxWidthAndHeight()
        {
            var radius = 5;
            var width = 6;
            var height = 8;
            var compactor = new Compactor(radius, _inCircleChecker);
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