﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class LighteningParameters : IParameters
    {
        public double Coefficient;

        public ParameterInfo[] GetDescription()
            => new[]
            {
                new ParameterInfo { Name="Коэффициент", MaxValue=10, MinValue=0, Increment=0.1, DefaultValue=1 }
            };

        public void SetValues(double[] values)
        {
            Coefficient = values[0];
        }
    }
}
