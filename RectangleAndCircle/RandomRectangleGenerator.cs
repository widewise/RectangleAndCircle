using System;

namespace RectangleAndCircle
{
    public class RandomRectangleGenerator : IRectangleGenerator
    {
        public const int MinSize = 1;
        private readonly Random _random = new Random();

        public RectangleParams GenerateRectangle(int epsilon)
        {
            if (epsilon <= MinSize)
            {
                throw new ArgumentException(nameof(epsilon));
            }

            var a = _random.Next(MinSize, epsilon);
            var b = _random.Next(MinSize, epsilon);

            return new RectangleParams(a, b);
        }
    }
}