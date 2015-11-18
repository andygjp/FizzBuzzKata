namespace FizzBuzz
{
    internal class MathHelper
    {
        public static bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }

    internal interface IConvert
    {
        string Convert(int input, string returnValue);
    }

    internal class Fizzer : NumberToString
    {
        public Fizzer() : base("Fizz", 3)
        {
        }
    }

    internal class Buzzer : NumberToString
    {
        public Buzzer() : base("Buzz", 5)
        {
        }
    }

    internal abstract class NumberToString : IConvert
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

    internal class Fallback : IConvert
    {
        public string Convert(int input, string returnValue)
        {
            if (string.IsNullOrWhiteSpace(returnValue))
            {
                returnValue = input.ToString();
            }
            return returnValue;
        }
    }

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
