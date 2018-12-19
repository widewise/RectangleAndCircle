using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleParamsGenerator
{
    public interface IRectangleParamsGenerator
    {
        int Epsilon { get; }
        RectangleParams GenerateRectangleParams();
    }
}