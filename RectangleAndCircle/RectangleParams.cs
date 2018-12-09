using System;

namespace RectangleAndCircle
{
    public class RectangleParams
    {
        public double A { get; }
        public double B { get; }

        public RectangleParams(
            double a,
            double b)
        {
            if (a <= 0)
            {
                throw new ArgumentException(nameof(a));
            }
            if (b <= 0)
            {
                throw new ArgumentException(nameof(b));
            }

            A = a;
            B = b;
        }
    }
}