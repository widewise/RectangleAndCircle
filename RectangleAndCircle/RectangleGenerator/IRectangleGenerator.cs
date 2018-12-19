using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.RectangleGenerator
{
    public interface IRectangleGenerator
    {
        int Radius { get; }

        RectangleD GenerateRectangleInCircle(RectangleParams rectangleParams);
    }
}
