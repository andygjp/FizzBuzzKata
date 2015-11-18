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
            return input.ToString();
        }
    }
}
