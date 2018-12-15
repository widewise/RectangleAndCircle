using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RectangleAndCircle.Compactor;
using RectangleAndCircle.RectangleGenerator;

namespace RectangleAndCircle.CircleFiller
{
    public class CircleFillerTests
    {
        [Test]
        public void ShouldThrowWhenEpsilonMoreRadius()
        {
            var radius = 2;
            var epsilon = radius + 1;
            var rectangleGeneratorMock = new Mock<IRectangleGenerator>();
            rectangleGeneratorMock.Setup(g => g.Epsilon).Returns(() => epsilon);
            var compactorMock = new Mock<ICompactor>();
            compactorMock.Setup(c => c.Radius).Returns(() => radius);

            Action action = () => new CircleFiller(rectangleGeneratorMock.Object, compactorMock.Object);

            action.Should().Throw<ArgumentException>();
        }
    }
}