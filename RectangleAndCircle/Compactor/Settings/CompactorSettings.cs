using System;

namespace RectangleAndCircle.Compactor.Settings
{
    public class CompactorSettings
    {
        public const int MinRadius = 1;
        public int Radius { get; }
        public int AddAttemptCount { get; }

        public CompactorSettings(
            int radius,
            int addAttemptCount)
        {
            if (radius <= MinRadius)
            {
                throw new ArgumentException(nameof(radius));
            }

            if (addAttemptCount <= 0)
            {
                throw new ArgumentException(nameof(addAttemptCount));
            }

            Radius = radius;
            AddAttemptCount = addAttemptCount;
        }
    }
}