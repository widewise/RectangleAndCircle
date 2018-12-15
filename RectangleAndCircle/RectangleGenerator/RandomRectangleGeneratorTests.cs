using System;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle.RectangleGenerator
{
    public class RandomRectangleGeneratorTests
    {
        [Test]
        public void SouldThrowThenEpsilonLessMinSize()
        {
            Action action = () => new RandomRectangleGenerator(RandomRectangleGenerator.MinSize - 1);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SouldGetRectangleParamsThenEpsilonMoreMinSize()
        {
            var epsilon = 100;
            var rectangleGenerator = new RandomRectangleGenerator(epsilon);

            var recParams = rectangleGenerator.GenerateRectangle();

            recParams.Should().NotBeNull();
            recParams.Width.Should().BeGreaterOrEqualTo(RandomRectangleGenerator.MinSize);
            recParams.Width.Should().BeLessOrEqualTo(epsilon);
            recParams.Height.Should().BeGreaterOrEqualTo(RandomRectangleGenerator.MinSize);
            recParams.Height.Should().BeLessOrEqualTo(epsilon);
        }
    }
}