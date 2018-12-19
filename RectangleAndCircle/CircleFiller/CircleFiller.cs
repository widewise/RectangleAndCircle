using System;
using System.Collections.Generic;
using RectangleAndCircle.Compactor;
using RectangleAndCircle.Rectangle;
using RectangleAndCircle.RectangleParamsGenerator;

namespace RectangleAndCircle.CircleFiller
{
    internal class CircleFiller : ICircleFiller
    {
        private readonly IRectangleParamsGenerator _rectangleParamsGenerator;
        private readonly ICompactor _compactor;

        internal CircleFiller(
            IRectangleParamsGenerator rectangleParamsGenerator,
            ICompactor compactor)
        {
            _rectangleParamsGenerator = rectangleParamsGenerator ?? throw new ArgumentNullException(nameof(rectangleParamsGenerator));
            _compactor = compactor ?? throw  new ArgumentNullException(nameof(compactor));

            if (rectangleParamsGenerator.Epsilon > compactor.Radius)
            {
                throw new ArgumentException();
            }
        }
        public IEnumerable<RectangleD> GetRectangles()
        {
            bool rectangleIsAdded;
            do
            {
                var rectangleParams = _rectangleParamsGenerator.GenerateRectangleParams();
                rectangleIsAdded = _compactor.AddRectangle(rectangleParams);
            }
            while (rectangleIsAdded);

            return _compactor.Rectangles;
        }
    }
}