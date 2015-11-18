namespace FizzBuzz
{
    public class Converter
    {
        private readonly NumberToString _fizzer = new Fizzer();
        private readonly NumberToString _buzzer = new Buzzer();
        private readonly Fallback _fallback = new Fallback();

        public string Convert(int input)
        {
            string returnValue = "";
            var converters = new IConvert[] {_fizzer, _buzzer, _fallback};
            foreach (var converter in converters)
            {
                returnValue = ReturnValue(input, returnValue, converter);
            }
            return returnValue;
        }

        private string ReturnValue(int input, string returnValue, IConvert converter)
        {
            returnValue = converter.Convert(input, returnValue);
            return returnValue;
        }
    }
}
