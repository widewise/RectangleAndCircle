using System;
using System.Collections.Generic;

namespace RectangleAndCircle
{
    public class CircleFiller : ICircleFiller
    {
        private readonly IRectangleGenerator _rectangleGenerator;
        private static readonly double SquareSideAndCircleRadiusRatio = Math.Sqrt(2);
        public const double Eps = 0.001;

        public CircleFiller(
            IRectangleGenerator rectangleGenerator)
        {
            _rectangleGenerator = rectangleGenerator ?? throw new ArgumentNullException(nameof(rectangleGenerator));
        }
        public IEnumerable<RectangleD> GetRectangles(double radius, double rectangleMinSize)
        {
            if (radius <= 0)
            {
                throw new ArgumentException(nameof(radius));
            }

            if (rectangleMinSize <= 0)
            {
                throw new ArgumentException(nameof(rectangleMinSize));
            }

            if (rectangleMinSize / radius > SquareSideAndCircleRadiusRatio)
            {
                return new RectangleD[0];
            }

            var y = (SquareSideAndCircleRadiusRatio * radius) / 2;
            var x = -y;
            var size = 2 * y;

            return new []
            {
                new RectangleD(x, y, size, size)
            };
        }
    }
}