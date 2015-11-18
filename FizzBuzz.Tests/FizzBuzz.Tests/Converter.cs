namespace FizzBuzz
{
    using System;

    public class Converter
    {
        public string Convert(int input)
        {
            string returnValue = "";
            returnValue = AppendValueToReturnValueIfConditionIsMet(input, returnValue, ShouldReturnFizz, "Fizz");
            returnValue = AppendValueToReturnValueIfConditionIsMet(input, returnValue, ShouldReturnBuzz, "Buzz");
            returnValue = SetReturnValueIfEmptyToInput(input, returnValue);
            return returnValue;
        }

        private static string AppendValueToReturnValueIfConditionIsMet(int input, string returnValue, Predicate<int> predicate, string value)
        {
            if (predicate(input))
            {
                returnValue += value;
            }
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

        private static bool ShouldReturnFizz(int input)
        {
            return AnyRemainders(input, 3);
        }

        private static bool ShouldReturnBuzz(int input)
        {
            return AnyRemainders(input, 5);
        }

        private static bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }
}
