using System;
using System.Collections.Generic;

namespace RectangleAndCircle
{
    public class CircleFiller : ICircleFiller
    {
        public const int MinRadius = 1;
        private static readonly double SquareSideAndCircleRadiusRatio = Math.Sqrt(2);
        public const double Eps = 0.001;
        private readonly IRectangleGenerator _rectangleGenerator;

        public CircleFiller(
            IRectangleGenerator rectangleGenerator)
        {
            _rectangleGenerator = rectangleGenerator ?? throw new ArgumentNullException(nameof(rectangleGenerator));
        }
        public IEnumerable<RectangleD> GetRectangles(int radius, int epsilon)
        {
            if (radius <= MinRadius)
            {
                throw new ArgumentException(nameof(radius));
            }

            if (epsilon > radius)
            {
                throw new ArgumentException(nameof(epsilon));
            }

            var rectanglesList = new List<RectangleD>();

            do
            {
                var rectangleParams = _rectangleGenerator.GenerateRectangle(epsilon);
            } while (false);
            if (epsilon / radius > SquareSideAndCircleRadiusRatio)
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

        private bool CircleContainRectangle(RectangleD rec)
        {
            return true;
        }

        private bool IsFilled(IEnumerable<RectangleD> rectangles)
        {
            return true;
        }
    }
}