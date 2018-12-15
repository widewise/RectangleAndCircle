using System.Collections.Generic;
using RectangleAndCircle.Rectangle;

namespace RectangleAndCircle.Compactor
{
    public interface ICompactor
    {
        int Radius { get; }

        bool AddRectangle(RectangleParams rectangleParams);

        IEnumerable<RectangleD> Rectangles { get; }
    }
}