using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        public double R { get => r; set => r = Trim(value); }
        private double g;
        public double G { get => g; set => g = Trim(value); }
        private double b;
        public double B { get => b; set => b = Trim(value); }

        public Pixel(double _r, double _g, double _b)
        {
            r = g = b = 0;
            R = _r;
            G = _g;
            B = _b;
        }

        private double Check(double value)
            => value < 0 && value > 1 ? throw new ArgumentException() : value;
        private double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }
        public static Pixel operator* (Pixel pixel, double val)
        {
            return new Pixel(
                pixel.R * val, 
                pixel.G * val, 
                pixel.B * val
                );
        }
        public static Pixel operator *(double val, Pixel pixel)
            => pixel * val;

    }
}
