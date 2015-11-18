namespace FizzBuzz
{
    using System;

    public class thing
    {
        public string AppendValueToReturnValueIfConditionIsMet(int input, string returnValue, Predicate<int> predicate, string value)
        {
            if (predicate(input))
            {
                returnValue += value;
            }
            return returnValue;
        }

        public bool ShouldReturnFizz(int input)
        {
            return AnyRemainders(input, 3);
        }

        public bool ShouldReturnBuzz(int input)
        {
            return AnyRemainders(input, 5);
        }

        private bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }

    public class Converter
    {
        private readonly thing _thing = new thing();

        public string Convert(int input)
        {
            string returnValue = "";
            returnValue = _thing.AppendValueToReturnValueIfConditionIsMet(input, returnValue, _thing.ShouldReturnFizz, "Fizz");
            returnValue = _thing.AppendValueToReturnValueIfConditionIsMet(input, returnValue, _thing.ShouldReturnBuzz, "Buzz");
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
