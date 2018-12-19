using RectangleAndCircle.Compactor;
using RectangleAndCircle.RectangleGenerator;

namespace RectangleAndCircle.CircleFiller
{
    public static class CircleFillerFactory
    {
        public static ICircleFiller Create(int radius, int addAttemptCount, int epsilon)
        {
            var rectangleGenerator = new RectangleParamsGenerator(epsilon);
            var compactor = CompactorFactory.Create(radius, addAttemptCount);
            return new CircleFiller(rectangleGenerator, compactor);
        }
    }
}