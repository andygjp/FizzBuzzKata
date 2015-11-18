namespace FizzBuzz
{
    using System;

    internal class MathHelper
    {
        public static bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }

    internal class thing
    {
        private readonly Predicate<int> _predicate;
        private readonly string _value;
        private readonly int _divisor;

        public thing(Predicate<int> predicate, string value, int divisor)
        {
            _predicate = predicate;
            _value = value;
            _divisor = divisor;
        }

        public string AppendValueToReturnValueIfConditionIsMet(int input, string returnValue)
        {
            if (_predicate(input))
            {
                returnValue += _value;
            }
            return returnValue;
        }
    }

    public class Converter
    {
        private readonly thing _fizzer = new thing(input1 => MathHelper.AnyRemainders(input1, 3), "Fizz", 3);
        private readonly thing _buzzer = new thing(input2 => MathHelper.AnyRemainders(input2, 5), "Buzz", 5);

        public string Convert(int input)
        {
            string returnValue = "";
            returnValue = _fizzer.AppendValueToReturnValueIfConditionIsMet(input, returnValue);
            returnValue = _buzzer.AppendValueToReturnValueIfConditionIsMet(input, returnValue);
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
