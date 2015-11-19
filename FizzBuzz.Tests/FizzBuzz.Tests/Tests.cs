namespace FizzBuzz.Tests
{
    using System.Linq;
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

    public abstract class RuleConverter
    {
        protected abstract string Output { get; }
        protected abstract int Divisor { get; }

        public string GetOutput(int input)
        {
            return HasRemainders(input) ? Output : null;
        }

        private bool HasRemainders(int input)
        {
            return input % Divisor == 0;
        }
    }

    public class Fizzer : RuleConverter
    {
        protected override string Output => "Fizz";

        protected override int Divisor => 3;
    }

    public class Buzzer : RuleConverter
    {
        protected override string Output => "Buzz";

        protected override int Divisor => 5;
    }

    public class Converter
    {
        private readonly RuleConverter _fizzer = new Fizzer();
        private readonly RuleConverter _buzzer = new Buzzer();

        public string Convert(int input)
        {
            return ConvertUsingRules(input) ?? input.ToString();
        }

        private string ConvertUsingRules(int input)
        {
            var rules = new RuleConverter[] {_fizzer, _buzzer};
            return rules.Aggregate("", (current, x) => current + x.GetOutput(input)).DefaultIfNull();
            return (_fizzer.GetOutput(input) + _buzzer.GetOutput(input)).DefaultIfNull();
        }
    }
}
