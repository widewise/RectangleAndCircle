using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RectangleAndCircle.Rectangle;
using RectangleAndCircle.RectangleGenerator;

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
        public void ShouldRadiusEqual5WhenRectangleGeneratorRadiusEqual5()
        {
            var radius = 5;
            var addAttemptCount = 1;
            var rectangleGeneratorMock = new Mock<IRectangleGenerator>();
            rectangleGeneratorMock.Setup(g => g.Radius).Returns(() => radius);

            var compactor = new Compactor(addAttemptCount, rectangleGeneratorMock.Object);

            compactor.Radius.Should().Be(radius);
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

        [Test]
        public void ShouldFalseWhenGenerateSomeRectangles()
        {
            var addAttemptCount = 5;
            var rectangle = new RectangleD(1, 1, 1, 1);
            var rectangleGeneratorMock = new Mock<IRectangleGenerator>();
            rectangleGeneratorMock.Setup(g => g.GenerateRectangleInCircle(It.IsAny<RectangleParams>())).Returns(() => rectangle);
            var compactor = new Compactor(addAttemptCount, rectangleGeneratorMock.Object);
            compactor.AddRectangle(new RectangleParams(1, 1));

            var isAdded = compactor.AddRectangle(new RectangleParams(1, 1));

            isAdded.Should().BeFalse();
        }
    }
}