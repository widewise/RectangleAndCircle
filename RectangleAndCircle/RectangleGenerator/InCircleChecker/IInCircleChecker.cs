namespace RectangleAndCircle.RectangleGenerator.InCircleChecker
{
    public interface IInCircleChecker
    {
        bool RectangleInCricle(int x, int y, int width, int height, int radius);
        bool PointInCricle(int x, int y, int radius);
    }
}