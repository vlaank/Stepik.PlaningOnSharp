using System;

namespace MyPhotoshop
{
	public abstract class ParametrizedFilter : IFilter
	{
        IParameters parameters;
        public ParametrizedFilter(IParameters param)
        {
            parameters = param;
        }
        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDescription();
        }

        public Photo Process(Photo original, double[] param)
        {
            parameters.SetValues(param);
            return Process(original, parameters);
        }
        public abstract Photo Process(Photo original, IParameters param);
    }
}

