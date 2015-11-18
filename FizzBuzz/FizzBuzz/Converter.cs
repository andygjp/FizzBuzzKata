namespace FizzBuzz
{
    using System.Linq;

    public class Converter
    {
        private readonly NumberToString _fizzer = new Fizzer();
        private readonly NumberToString _buzzer = new Buzzer();
        private readonly Fallback _fallback = new Fallback();
        private readonly IConvert[] _converters;

        public Converter()
        {
            _converters = new IConvert[] {_fizzer, _buzzer, _fallback};
        }

        public string Convert(int input)
        {
            return _converters.Aggregate("", (current, converter) => ReturnValue(input, current, converter));
        }

        private string ReturnValue(int input, string returnValue, IConvert converter)
        {
            returnValue = converter.Convert(input, returnValue);
            return returnValue;
        }
    }
}
