using RectangleAndCircle.RectangleGenerator;

namespace RectangleAndCircle.Compactor
{
    public static class CompactorFactory
    {
        public static ICompactor Create(int radius, int addAttemptCount)
        {
            return new Compactor(addAttemptCount, RectangleGeneratorFactory.Create(radius));
        }
    }
}