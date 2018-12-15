using System;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleGenerator
{
    public class RandomRectangleGenerator : IRectangleGenerator
    {
        private readonly int _epsilon;
        private readonly Random _random = new Random();
        public const int MinSize = 1;
        public int Epsilon => _epsilon;

        public RandomRectangleGenerator(int epsilon)
        {
            if (epsilon <= MinSize)
            {
                throw new ArgumentException(nameof(_epsilon));
            }

            _epsilon = epsilon;
        }

        public RectangleParams GenerateRectangle()
        {
            var a = _random.Next(MinSize, _epsilon);
            var b = _random.Next(MinSize, _epsilon);

            return new RectangleParams(a, b);
        }
    }
}