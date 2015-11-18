namespace FizzBuzz.Tests
{
    using FluentAssertions;
    using Xunit;

    public class When_I_supply_a_number
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        public void It_should_convert_it_to_expected_value(int input, string expected)
        {
            var sut = new Converter();
            string actual = sut.Convert(input);
            actual.Should().Be(expected);
        }
    }

    public class Converter
    {
        public string Convert(int input)
        {
            string returnValue = "";
            if (ShouldReturnFizz(input))
            {
                returnValue += "Fizz";
            }
            if (ShouldReturnBuzz(input))
            {
                returnValue += "Buzz";
            }
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
