using System;
using System.Collections.Generic;
using System.Linq;
using RectangleAndCircle.Compactor.InCircleChecker;
using RectangleAndCircle.Compactor.Settings;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.Compactor
{
    internal class Compactor : ICompactor
    {
        private readonly CompactorSettings _settings;
        private readonly IInCircleChecker _inCircleChecker;
        private readonly int _diameter;
        private readonly IList<RectangleD> _rectangles;
        private readonly Random _random = new Random();

        public IEnumerable<RectangleD> Rectangles => _rectangles.ToArray();
        public int Radius => _settings.Radius;

        internal Compactor(
            CompactorSettings settings,
            IInCircleChecker inCircleChecker)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _inCircleChecker = inCircleChecker ?? throw new ArgumentNullException(nameof(inCircleChecker));

            _diameter = _settings.Radius * 2;
            _rectangles = new List<RectangleD>();
        }

        public bool AddRectangle(RectangleParams rectangleParams)
        {
            var addAttemptCount = _settings.AddAttemptCount;
            RectangleD rectangle;
            do
            {
                if (addAttemptCount == 0)
                {
                    return false;
                }

                rectangle = GenerateRectangleInCircle(rectangleParams);
                addAttemptCount--;
            }
            while (_rectangles.Any(r => r.IsIntersect(rectangle)));

            _rectangles.Add(rectangle);
            return true;
        }

        private RectangleD GenerateRectangleInCircle(RectangleParams rectangleParams)
        {
            if (rectangleParams == null)
            {
                throw new ArgumentNullException(nameof(rectangleParams));
            }

            var recRadius = Math.Sqrt(rectangleParams.Width * rectangleParams.Width + rectangleParams.Height * rectangleParams.Height) / 2;
            if (recRadius > _settings.Radius)
            {
                throw new PythagorasException(rectangleParams.Width, rectangleParams.Height, _settings.Radius);
            }

            if (recRadius == _settings.Radius)
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
                x = _random.Next(_diameter) - _settings.Radius;
                y = _random.Next(_diameter) - _settings.Radius;
            }
            while (!_inCircleChecker.RectangleInCricle(x, y, rectangleParams.Width, rectangleParams.Height, _settings.Radius));

            return new RectangleD(x, y, rectangleParams.Width, rectangleParams.Height);
        }
    }
}