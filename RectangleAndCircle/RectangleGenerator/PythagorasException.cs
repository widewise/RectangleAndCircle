using System;

namespace RectangleAndCircle.RectangleGenerator
{
    public class PythagorasException : Exception
    {
        public PythagorasException(int width, int height, int radius) : base(
            $"Радиус описанной окружности прямоугольника (ширина: {width}, высота: {height}) превышает заданный: {radius}")
        {

        }
    }
}