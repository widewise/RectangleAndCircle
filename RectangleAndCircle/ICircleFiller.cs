using System.Collections.Generic;

namespace RectangleAndCircle
{
    public interface ICircleFiller
    {
        IEnumerable<RectangleD> GetRectangles(int radius, int epsilon);
    }
}