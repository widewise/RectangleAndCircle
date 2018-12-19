using RectangleAndCircle.RectangleGenerator.InCircleChecker;

namespace RectangleAndCircle.RectangleGenerator
{
    public static class RectangleGeneratorFactory
    {
        private static readonly IInCircleChecker InCircleChecker = new InCircleChecker.InCircleChecker();

        public static IRectangleGenerator Create(int radius)
        {
            return new RectangleGenerator(radius, InCircleChecker);
        }
    }
}