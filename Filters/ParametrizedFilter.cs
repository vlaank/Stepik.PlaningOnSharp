namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters : IParameters, new()
    {
        public ParameterInfo[] GetParameters()
        {
            var parameters = new TParameters();
            return parameters.GetDescription();
        }

        public Photo Process(Photo original, double[] param)
        {
            var parameters = new TParameters();
            parameters.SetValues(param);
            return Process(original, parameters);
        }
        public abstract Photo Process(Photo original, TParameters param);
    }
}