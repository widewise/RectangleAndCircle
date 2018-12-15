using System;

namespace RectangleAndCircle.Compactor.InCircleChecker
{
    internal class InCircleChecker : IInCircleChecker
    {
        public bool RectangleInCricle(int x, int y, int width, int height, int radius)
        {
            return PointInCricle(x, y, radius) &&
                   PointInCricle(x, y - height, radius) &&
                   PointInCricle(x + width, y, radius) &&
                   PointInCricle(x + width, y - height, radius);
        }

        public bool PointInCricle(int x, int y, int radius)
        {
            return Math.Sqrt(x * x + y * y) <= radius;
        }
    }
}