namespace RectangleAndCircle
{
    public interface IRectangleGenerator
    {
        int Epsilon { get; }
        RectangleParams GenerateRectangle();
    }
}