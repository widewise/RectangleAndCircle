using System;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle
{
    public class RandomRectangleGeneratorTests
    {
        private IRectangleGenerator _rectangleGenerator;
        [SetUp]
        public void Setup()
        {
            _rectangleGenerator = new RandomRectangleGenerator();
        }
        [Test]
        public void SouldThrowThenEpsilonLessMinSize()
        {
            Action action = () => _rectangleGenerator.GenerateRectangle(RandomRectangleGenerator.MinSize);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SouldGetRectangleParamsThenEpsilonMoreMinSize()
        {
            var epsilon = 100;

            var recParams = _rectangleGenerator.GenerateRectangle(epsilon);

            recParams.Should().NotBeNull();
            recParams.A.Should().BeGreaterOrEqualTo(RandomRectangleGenerator.MinSize);
            recParams.A.Should().BeLessOrEqualTo(epsilon);
            recParams.B.Should().BeGreaterOrEqualTo(RandomRectangleGenerator.MinSize);
            recParams.B.Should().BeLessOrEqualTo(epsilon);
        }
    }
}