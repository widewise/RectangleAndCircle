﻿using System;
using System.Collections.Generic;

namespace RectangleAndCircle
{
    public class CircleFiller : ICircleFiller
    {
        private readonly IRectangleGenerator _rectangleGenerator;
        private readonly ICompactor _compactor;

        public CircleFiller(
            IRectangleGenerator rectangleGenerator,
            ICompactor compactor)
        {
            _rectangleGenerator = rectangleGenerator ?? throw new ArgumentNullException(nameof(rectangleGenerator));
            _compactor = compactor ?? throw  new ArgumentNullException(nameof(compactor));

            if (rectangleGenerator.Epsilon > compactor.Radius)
            {
                throw new ArgumentException();
            }
        }
        public IEnumerable<RectangleD> GetRectangles()
        {
            bool rectanglesEdited;
            do
            {
                var rectangleParams = _rectangleGenerator.GenerateRectangle();
                rectanglesEdited = _compactor.AddRectangle(rectangleParams);
            }
            while (rectanglesEdited);

            return _compactor.Rectangles;
        }
    }
}