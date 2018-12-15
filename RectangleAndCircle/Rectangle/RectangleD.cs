using System;

namespace RectangleAndCircle.Rectangle
{
    public class RectangleD
    {
        public RectangleD(
            double x,
            double y,
            double width,
            double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException(nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException(nameof(height));
            }

            X = x;
            Y = y;
            Width = width;
            Height = height;
            _x1 = x + width;
            _y1 = y - height;
        }

        public double X { get; }
        public double Y { get; }
        public double Width { get; }
        public double Height { get; }

        private readonly double _x1;
        private readonly double _y1;

        public bool IsIntersect(RectangleD rec)
        {
            if (rec == null)
            {
                throw new ArgumentNullException(nameof(rec));
            }

            return !(Y < rec._y1 || _y1 > rec.Y || _x1 < rec.X || X > rec._x1);
        }
    }
}