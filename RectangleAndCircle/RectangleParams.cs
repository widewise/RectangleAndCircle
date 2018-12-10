using System;

namespace RectangleAndCircle
{
    public class RectangleParams
    {
        public int A { get; }
        public int B { get; }

        public RectangleParams(
            int a,
            int b)
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