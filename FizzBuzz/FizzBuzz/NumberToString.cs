namespace FizzBuzz
{
    internal abstract class NumberToString : IConvert
    {
        private readonly string _value;
        private readonly int _divisor;

        protected NumberToString(string value, int divisor)
        {
            _value = value;
            _divisor = divisor;
        }

        public string Convert(int input, string returnValue)
        {
            if (MathHelper.AnyRemainders(input, _divisor))
            {
                returnValue += _value;
            }
            return returnValue;
        }
    }
}