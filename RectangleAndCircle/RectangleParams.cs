using System;

namespace RectangleAndCircle
{
    public class RectangleParams
    {
        public int Width { get; }
        public int Height { get; }

        public RectangleParams(
            int width,
            int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException(nameof(width));
            }
            if (height <= 0)
            {
                throw new ArgumentException(nameof(height));
            }

            Width = width;
            Height = height;
        }
    }
}