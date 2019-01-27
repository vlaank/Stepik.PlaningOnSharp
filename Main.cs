using System;
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
            Application.Run(window);
        }
    }
}
