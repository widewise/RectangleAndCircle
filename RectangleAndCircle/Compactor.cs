using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleAndCircle
{
    public class Compactor : ICompactor
    {
        private readonly int _radius;
        private readonly IInCircleChecker _inCircleChecker;
        private readonly int _diameter;
        private readonly IList<RectangleD> _rectangles;

        public const int MinRadius = 1;

        public IEnumerable<RectangleD> Rectangles => _rectangles.ToArray();
        public int Radius => _radius;

        public Compactor(
            int radius,
            IInCircleChecker inCircleChecker)
        {
            if (radius <= MinRadius)
            {
                throw new ArgumentException(nameof(radius));
            }

            _radius = radius;
            _inCircleChecker = inCircleChecker ?? throw new ArgumentNullException(nameof(inCircleChecker));

            _diameter = radius * 2;
            _rectangles = new List<RectangleD>();
        }

        public bool AddRectangle(RectangleParams rectangleParams)
        {
            var rectangleD = GenerateRectangleInCircle(rectangleParams);
            if (_rectangles.Any(r => r.IsIntersect(rectangleD)))
            {
                return false;
            }

            _rectangles.Add(rectangleD);
            return true;
        }

        private RectangleD GenerateRectangleInCircle(RectangleParams rectangleParams)
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
            var random = new Random();
            do
            {
                x = random.Next(_diameter) - _radius;
                y = random.Next(_diameter) - _radius;
            }
            while (!_inCircleChecker.RectangleInCricle(x, y, rectangleParams.Width, rectangleParams.Height, _radius));

            return new RectangleD(x, y, rectangleParams.Width, rectangleParams.Height);
        }
    }
}