using System.Collections.Generic;

namespace RectangleAndCircle
{
    public interface ICircleFiller
    {
        IEnumerable<RectangleD> GetRectangles(double radius, double rectangleMinSize);
    }
}