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
            returnValue = ReturnValue(input, returnValue, _buzzer);
            returnValue = ReturnValue(input, returnValue, _fallback);
            return returnValue;
        }

        private string ReturnValue(int input, string returnValue, IConvert converter)
        {
            returnValue = converter.Convert(input, returnValue);
            return returnValue;
        }
    }
}
