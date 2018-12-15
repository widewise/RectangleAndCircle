using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleGenerator
{
    public interface IRectangleGenerator
    {
        int Epsilon { get; }
        RectangleParams GenerateRectangle();
    }
}