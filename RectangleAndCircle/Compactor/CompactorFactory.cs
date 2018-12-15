using RectangleAndCircle.Compactor.InCircleChecker;
using RectangleAndCircle.Compactor.Settings;

namespace RectangleAndCircle.Compactor
{
    public static class CompactorFactory
    {
        private static readonly IInCircleChecker InCircleChecker = new InCircleChecker.InCircleChecker();

        public static ICompactor Create(int radius, int addAttemptCount)
        {
            return new Compactor(new CompactorSettings(radius, addAttemptCount), InCircleChecker);
        }
    }
}