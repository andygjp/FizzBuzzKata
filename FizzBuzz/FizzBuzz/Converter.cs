namespace FizzBuzz
{
    internal class MathHelper
    {
        public static bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }

    internal class NumberToString
    {
        private readonly string _value;
        private readonly int _divisor;

        public NumberToString(string value, int divisor)
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

    public class Converter
    {
        private readonly NumberToString _fizzer = new NumberToString("Fizz", 3);
        private readonly NumberToString _buzzer = new NumberToString("Buzz", 5);

        public string Convert(int input)
        {
            string returnValue = "";
            returnValue = _fizzer.Convert(input, returnValue);
            returnValue = _buzzer.Convert(input, returnValue);
            returnValue = SetReturnValueIfEmptyToInput(input, returnValue);
            return returnValue;
        }

        private static string SetReturnValueIfEmptyToInput(int input, string returnValue)
        {
            if (string.IsNullOrWhiteSpace(returnValue))
            {
                returnValue = input.ToString();
            }
            return returnValue;
        }
    }
}
