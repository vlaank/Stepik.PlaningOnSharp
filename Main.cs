using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var window = new MainWindow();
            window.AddFilter(new PixelFilter<EmptyParameters>(
                "������� ������",
                (original, param) =>
                {
                    var lightness = original.R + original.G + original.B;
                    lightness /= 3;
                    return new Pixel(lightness, lightness, lightness);
                }
                ));
            window.AddFilter(new PixelFilter<LighteningParameters>(
                "���������� / ����������",
                (original, parameters)
                => original * parameters.Coefficient
                ));
            window.AddFilter(new TransformFilter(
                "�������� �� �����������",
                size => size,
                (point, size)
                => new Point(size.Width - point.X - 1, point.Y)
                ));
            window.AddFilter(new TransformFilter(
                "��������� �� 90 �������� ������ �. �.",
                size => new Size(size.Height, size.Width),
                (point, size)
                => new Point(point.Y, point.X)
                ));
            Application.Run(window);
        }
    }
}
