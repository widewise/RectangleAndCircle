using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle
{
    public class InCircleCheckerTests
    {
        private IInCircleChecker _circleChecker;
        [SetUp]
        public void Setup()
        {
            _circleChecker = new InCircleChecker();
        }

        [Test]
        public void ShouldFalseWhenPointNotInCircle()
        {
            var inCircle = _circleChecker.PointInCricle(-2, 2, 2);
            inCircle.Should().BeFalse();
        }

        [Test]
        public void ShouldTrueWhenPointOnCircleLine()
        {
            var inCircle = _circleChecker.PointInCricle(6, 8, 10);
            inCircle.Should().BeTrue();
        }

        [Test]
        public void ShouldTrueWhenPointInCircle()
        {
            var inCircle = _circleChecker.PointInCricle(1, 1, 5);
            inCircle.Should().BeTrue();
        }

        [Test]
        public void ShouldTrueWhenAllRectanglePointsInCircle()
        {
            var inCircle = _circleChecker.RectangleInCricle(1, 1, 1, 1, 5);
            inCircle.Should().BeTrue();
        }

        [Test]
        public void ShouldFalseWhenAllRectanglePointsNotInCircle()
        {
            var inCircle = _circleChecker.RectangleInCricle(-3, 3, 6, 6, 1);
            inCircle.Should().BeFalse();
        }

        [Test]
        public void ShouldFalseWhenOnePointOfRectangleNotInCircle()
        {
            var inCircle = _circleChecker.RectangleInCricle(0, 0, 4, 4, 5);
            inCircle.Should().BeFalse();
        }
    }
}