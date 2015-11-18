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
            returnValue = ReturnValue(input, returnValue, _fizzer);
            returnValue = _buzzer.Convert(input, returnValue);
            returnValue = _fallback.Convert(input, returnValue);
            return returnValue;
        }

        private string ReturnValue(int input, string returnValue, IConvert converter)
        {
            returnValue = converter.Convert(input, returnValue);
            return returnValue;
        }
    }
}
