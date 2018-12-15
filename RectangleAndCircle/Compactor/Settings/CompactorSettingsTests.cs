using System;
using FluentAssertions;
using NUnit.Framework;

namespace RectangleAndCircle.Compactor.Settings
{
    public class CompactorSettingsTests
    {
        [Test]
        public void ShouldThrowWhenRadiusEqualMinRadius()
        {
            Action action = () => new CompactorSettings(CompactorSettings.MinRadius, 5);
            action.Should().Throw<ArgumentException>();
        }
        [Test]
        public void ShouldThrowWhenAddAttemptCountEqualZero()
        {
            Action action = () => new CompactorSettings(3, 0);
            action.Should().Throw<ArgumentException>();
        }
    }
}