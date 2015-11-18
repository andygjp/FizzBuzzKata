namespace FizzBuzz
{
    using System;

    public class MathHelper
    {
        public static bool AnyRemainders(int leftOperand, int rightOperand)
        {
            return leftOperand % rightOperand == 0;
        }
    }

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
    }

    public class Converter
    {
        private readonly thing _fizzer = new thing();
        private readonly thing _buzzer = new thing();

        public string Convert(int input)
        {
            string returnValue = "";
            returnValue = _fizzer.AppendValueToReturnValueIfConditionIsMet(input, returnValue, input1 => MathHelper.AnyRemainders(input1, 3), "Fizz");
            returnValue = _buzzer.AppendValueToReturnValueIfConditionIsMet(input, returnValue, input2 => MathHelper.AnyRemainders(input2, 5), "Buzz");
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
