using System.Collections.Generic;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.CircleFiller
{
    public interface ICircleFiller
    {
        IEnumerable<RectangleD> GetRectangles();
    }
}