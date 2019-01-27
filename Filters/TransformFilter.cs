using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        private readonly string filterName;
        private Func<Size, Size> sizeTransform;
        private Func<Point, Size, Point> pointTransform;

        public TransformFilter(string name, Func<Size, Size> sizeTrans, Func<Point, Size, Point> pointTrans)
        {
            filterName = name;
            sizeTransform = sizeTrans;
            pointTransform = pointTrans;
        }

        public override string ToString()
        {
            return filterName;
        }

        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    var oldPoint = new Point(x, y);
                    var newPoint = pointTransform(oldPoint, oldSize);
                    result[x, y] = original[newPoint.X, newPoint.Y];
                }
            }
            return result;
        }
    }
}