using System;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle.RectangleGenerator
{
    public class RectangleParamsGeneratorTests
    {
        [Test]
        public void SouldThrowThenEpsilonLessMinSize()
        {
            Action action = () => new RectangleParamsGenerator(RectangleParamsGenerator.MinSize - 1);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SouldGetRectangleParamsThenEpsilonMoreMinSize()
        {
            var epsilon = 100;
            var rectangleGenerator = new RectangleParamsGenerator(epsilon);

            var recParams = rectangleGenerator.GenerateRectangleParams();

            recParams.Should().NotBeNull();
            recParams.Width.Should().BeGreaterOrEqualTo(RectangleParamsGenerator.MinSize);
            recParams.Width.Should().BeLessOrEqualTo(epsilon);
            recParams.Height.Should().BeGreaterOrEqualTo(RectangleParamsGenerator.MinSize);
            recParams.Height.Should().BeLessOrEqualTo(epsilon);
        }
    }
}