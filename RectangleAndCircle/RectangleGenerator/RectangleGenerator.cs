using System;
using RectangleAndCircle.Compactor;
using RectangleAndCircle.Rectangle;
using RectangleAndCircle.RectangleGenerator.InCircleChecker;

namespace RectangleAndCircle.RectangleGenerator
{
    internal class RectangleGenerator : IRectangleGenerator
    {
        private readonly int _radius;
        private readonly int _diameter;
        private readonly Random _random = new Random();
        private readonly IInCircleChecker _inCircleChecker;
        public const int MinRadius = 1;
        public int Radius => _radius;

        internal RectangleGenerator(
            int radius,
            IInCircleChecker inCircleChecker)
        {
            if (radius <= MinRadius)
            {
                throw new ArgumentException(nameof(radius));
            }

            _radius = radius;
            _diameter = radius * 2;
            _inCircleChecker = inCircleChecker ?? throw new ArgumentNullException(nameof(inCircleChecker));
        }

        public RectangleD GenerateRectangleInCircle(RectangleParams rectangleParams)
        {
            if (rectangleParams == null)
            {
                throw new ArgumentNullException(nameof(rectangleParams));
            }

            var recRadius = Math.Sqrt(rectangleParams.Width * rectangleParams.Width + rectangleParams.Height * rectangleParams.Height) / 2;
            if (recRadius > _radius)
            {
                throw new PythagorasException(rectangleParams.Width, rectangleParams.Height, _radius);
            }

            if (recRadius == _radius)
            {
                return new RectangleD(
                    -rectangleParams.Width / 2,
                    rectangleParams.Height / 2,
                    rectangleParams.Width,
                    rectangleParams.Height);
            }

            int x, y;
            do
            {
                x = _random.Next(_diameter) - _radius;
                y = _random.Next(_diameter) - _radius;
            }
            while (!_inCircleChecker.RectangleInCricle(x, y, rectangleParams.Width, rectangleParams.Height, _radius));

            return new RectangleD(x, y, rectangleParams.Width, rectangleParams.Height);
        }
    }
}