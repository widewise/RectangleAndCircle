using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RectangleAndCircle.Compactor;
using RectangleAndCircle.Rectangle;
using RectangleAndCircle.RectangleParamsGenerator;

namespace RectangleAndCircle.CircleFiller
{
    public class CircleFillerTests
    {
        [Test]
        public void ShouldThrowWhenEpsilonMoreRadius()
        {
            var radius = 2;
            var epsilon = radius + 1;
            var rectangleParamsGeneratorMock = new Mock<IRectangleParamsGenerator>();
            rectangleParamsGeneratorMock.Setup(g => g.Epsilon).Returns(() => epsilon);
            var compactorMock = new Mock<ICompactor>();
            compactorMock.Setup(c => c.Radius).Returns(() => radius);

            Action action = () => new CircleFiller(rectangleParamsGeneratorMock.Object, compactorMock.Object);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldGetRectanglesWhenGetRectangles()
        {
            var recCount = 5;
            var index = 0;
            var rectangles = new List<RectangleD>();

            var rectangleParamsGeneratorMock = new Mock<IRectangleParamsGenerator>();
            rectangleParamsGeneratorMock.Setup(g => g.GenerateRectangleParams()).Returns(
                () =>
                {
                    index++;
                    return new RectangleParams(index, index);
                });
            var compactorMock = new Mock<ICompactor>();
            compactorMock.Setup(c => c.AddRectangle(It.IsAny<RectangleParams>())).Returns(
                (RectangleParams rectangleParams) =>
                {
                    if (index <= recCount)
                    {
                        rectangles.Add(new RectangleD(0, 0, rectangleParams.Width, rectangleParams.Height));
                        return true;
                    }

                    return false;
                });
            compactorMock.Setup(c => c.Rectangles).Returns(() => rectangles.ToArray());

            var filler =  new CircleFiller(rectangleParamsGeneratorMock.Object, compactorMock.Object);

            var result = filler.GetRectangles();

            result.Should().NotBeNull();
            result.Count().Should().Be(recCount);
            foreach (var resultRectangle in result)
            {
                resultRectangle.X.Should().Be(0);
                resultRectangle.Y.Should().Be(0);
                resultRectangle.Height.Should().Be(resultRectangle.Width);
            }
        }
    }
}