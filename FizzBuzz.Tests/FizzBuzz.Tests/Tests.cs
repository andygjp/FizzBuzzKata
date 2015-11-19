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

    public class When_I_convert_a_multiple_of_five
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void It_should_convert_it_to_Buzz(int input)
        {
            var sut = new Converter();
            string actual = sut.Convert(input);
            actual.Should().Be("Buzz");
        }
    }

    public class When_I_convert_a_multiple_of_three_and_five
    {
        [Fact]
        public void It_should_convert_it_to_FizzBuzz()
        {
            var sut = new Converter();
            string actual = sut.Convert(15);
            actual.Should().Be("FizzBuzz");
        }
    }

    internal static class StringExtension
    {
        public static string DefaultIfNull(this string value)
        {
            return value.Length == 0 ? null : value;
        }
    }

    public class Fizzer
    {
        public string Fizz(int input)
        {
            return IsFizzy(input) ? "Fizz" : null;
        }

        private bool IsFizzy(int input)
        {
            return Helper.AnyRemainders(input, 3);
        }
    }

    public class Buzer
    {
        public string Buzz(int input)
        {
            return IsBuzzy(input) ? "Buzz" : null;
        }

        private bool IsBuzzy(int input)
        {
            return Helper.AnyRemainders(input, 5);
        }
    }

    public class Converter
    {
        private readonly Fizzer _fizzer = new Fizzer();
        private readonly Buzer _buzer = new Buzer();

        public string Convert(int input)
        {
            return FizzBuzz(input) ?? input.ToString();
        }

        private string FizzBuzz(int input)
        {
            return (_fizzer.Fizz(input) + _buzer.Buzz(input)).DefaultIfNull();
        }
    }

    internal static class Helper
    {
        public static bool AnyRemainders(int input, int divisor)
        {
            return input % divisor == 0;
        }
    }
}
