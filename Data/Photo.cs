using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		public readonly Pixel[,] data;

		public Photo(int _width, int _height)
		{
			width = _width;
			height = _height;
			data = new Pixel[_width, _height];
		}
		public Pixel this[int x, int y]
		{
			get => data[x, y];
			set => data[x, y] = value;
		}
	}
}

