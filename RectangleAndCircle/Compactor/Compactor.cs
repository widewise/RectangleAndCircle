using System;
using System.Collections.Generic;
using System.Linq;
using RectangleAndCircle.Rectangle;
using RectangleAndCircle.RectangleGenerator;

namespace RectangleAndCircle.Compactor
{
    internal class Compactor : ICompactor
    {
        private readonly int _addAttemptCount;
        private readonly IRectangleGenerator _rectangleGenerator;
        private readonly IList<RectangleD> _rectangles;

        public int Radius => _rectangleGenerator.Radius;
        public IEnumerable<RectangleD> Rectangles => _rectangles.ToArray();

        internal Compactor(
            int addAttemptCount,
            IRectangleGenerator rectangleGenerator)
        {
            if (addAttemptCount <= 0)
            {
                throw new ArgumentException(nameof(addAttemptCount));
            }

            _addAttemptCount = addAttemptCount;
            _rectangleGenerator = rectangleGenerator ?? throw new ArgumentNullException(nameof(rectangleGenerator));
            _rectangles = new List<RectangleD>();
        }

        public bool AddRectangle(RectangleParams rectangleParams)
        {
            var addAttemptCount = _addAttemptCount;
            RectangleD rectangle;
            do
            {
                if (addAttemptCount == 0)
                {
                    return false;
                }

                rectangle = _rectangleGenerator.GenerateRectangleInCircle(rectangleParams);
                addAttemptCount--;
            }
            while (_rectangles.Any(r => r.IsIntersect(rectangle)));

            _rectangles.Add(rectangle);
            return true;
        }
    }
}