using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleGenerator
{
    public interface IRectangleParamsGenerator
    {
        int Epsilon { get; }
        RectangleParams GenerateRectangleParams();
    }
}