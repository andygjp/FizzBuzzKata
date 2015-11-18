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
            returnValue = _fizzer.Convert(input, returnValue);
            returnValue = _buzzer.Convert(input, returnValue);
            returnValue = _fallback.Convert(input, returnValue);
            return returnValue;
        }
    }
}
