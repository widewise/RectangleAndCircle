using System.Collections.Generic;

namespace RectangleAndCircle
{
    public interface ICompactor
    {
        int Radius { get; }

        bool AddRectangle(RectangleParams rectangleParams);

        IEnumerable<RectangleD> Rectangles { get; }
    }
}