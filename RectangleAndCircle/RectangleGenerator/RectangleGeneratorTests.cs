using System;
using FluentAssertions;
using NUnit.Framework;
using RectangleAndCircle.Compactor;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleGenerator
{
    public class RectangleGeneratorTests
    {
        [Test]
        public void ShouldThrowWhenRadiusEqualMinRadius()
        {
            Action action = () => RectangleGeneratorFactory.Create(RectangleGenerator.MinRadius);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldTrueThenAddRectangleWithWidthAndHeightLessDiameter()
        {
            var generator = RectangleGeneratorFactory.Create(10);
            var rectangleParams = new RectangleParams(2, 3);

            var rectangle = generator.GenerateRectangleInCircle(rectangleParams);

            rectangle.Should().NotBeNull();
        }

        [Test]
        public void ShouldThrowThenGenerateRectangleWithWidthMoreDiameter()
        {
            var generator = RectangleGeneratorFactory.Create(2);
            var rectangleParams = new RectangleParams(5, 3);

            Action action = () => generator.GenerateRectangleInCircle(rectangleParams);

            action.Should().Throw<PythagorasException>();
        }

        [Test]
        public void ShouldThrowThenGenerateRectangleWithHieghtMoreDiameter()
        {
            var generator = RectangleGeneratorFactory.Create(2);
            var rectangleParams = new RectangleParams(3, 5);

            Action action = () => generator.GenerateRectangleInCircle(rectangleParams);

            action.Should().Throw<PythagorasException>();
        }
    }
}