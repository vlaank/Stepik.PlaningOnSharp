namespace MyPhotoshop
{
    public class Photo
    {
        public readonly int Width;
        public readonly int Height;
        public readonly Pixel[,] data;

        public Photo(int _width, int _height)
        {
            Width = _width;
            Height = _height;
            data = new Pixel[_width, _height];
        }
        public Pixel this[int x, int y]
        {
            get => data[x, y];
            set => data[x, y] = value;
        }
    }
}