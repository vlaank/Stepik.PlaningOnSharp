﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters param) : base(param) { }

        public override Photo Process(Photo original, IParameters parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
            {
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = ProcessPixel(original[x,y], parameters);
                }
            }

            return result;
        }

        public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);

    }
}
