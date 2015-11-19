namespace FizzBuzz.Tests
{
    using FluentAssertions;
    using Xunit;

    public class When_I_convert_a_normal_number
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        public void It_should_convert_it_to_expected_value(int input, string expected)
        {
            var sut = new Converter();
            string actual = sut.Convert(input);
            actual.Should().Be(expected);
        }
    }

    public class When_I_convert_a_multiple_of_three
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void It_should_convert_it_to_Fizz(int input)
        {
            var sut = new Converter();
            string actual = sut.Convert(input);
            actual.Should().Be("Fizz");
        }
    }

    public class Converter
    {
        public string Convert(int input)
        {
            return Fizz(input) ?? input.ToString();
        }

        private static string Fizz(int input)
        {
            return IsFizzy(input) ? "Fizz" : null;
        }

        private static bool IsFizzy(int input)
        {
            return AnyRemainders(input, 3);
        }

        private static bool AnyRemainders(int input, int divisor)
        {
            return input % divisor == 0;
        }
    }
}
