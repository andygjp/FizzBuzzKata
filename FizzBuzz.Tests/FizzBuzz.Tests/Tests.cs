﻿namespace FizzBuzz.Tests
{
    using System.Collections.Generic;
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

    public class When_I_convert_a_multiple_of_seven
    {
        [Fact]
        public void It_should_convert_it_to_Pop()
        {
            var sut = new Converter();
            string actual = sut.Convert(7);
            actual.Should().Be("Pop");
        }
    }

    public class When_I_convert_a_multiple_of_three_and_seven
    {
        [Fact]
        public void It_should_convert_it_to_FizzBuzz()
        {
            var sut = new Converter();
            string actual = sut.Convert(21);
            actual.Should().Be("FizzPop");
        }
    }

    public class When_I_convert_a_multiple_of_five_and_seven
    {
        [Fact]
        public void It_should_convert_it_to_FizzBuzz()
        {
            var sut = new Converter();
            string actual = sut.Convert(35);
            actual.Should().Be("BuzzPop");
        }
    }

    public class When_I_convert_a_multiple_of_three_and_five_and_seven
    {
        [Fact]
        public void It_should_convert_it_to_FizzBuzz()
        {
            var sut = new Converter();
            string actual = sut.Convert(105);
            actual.Should().Be("FizzBuzzPop");
        }
    }

    public class When_I_convert_input_using_my_own_rule
    {
        [Fact]
        public void It_should_convert_it_to_Fuzz()
        {
            var sut = new Converter(new RuleConverter("Fuzz", 2));
            string actual = sut.Convert(2);
            actual.Should().Be("Fuzz");
        }
    }

    public class When_I_convert_input_using_many_custom_rules
    {
        [Fact]
        public void It_should_convert_it_to_Fuzz()
        {
            var sut = new Converter(new[] {new RuleConverter("Fuzz", 2), new RuleConverter("Bizz", 3)});
            string actual = sut.Convert(6);
            actual.Should().Be("FuzzBizz");
        }
    }

    internal static class StringExtension
    {
        public static string DefaultIfNull(this string value)
        {
            return value.Length == 0 ? null : value;
        }
    }

    public class RuleConverter
    {
        private readonly string _output;
        private readonly int _divisor;

        public RuleConverter(string output, int divisor)
        {
            _output = output;
            _divisor = divisor;
        }

        public string GetOutput(int input)
        {
            return HasRemainders(input) ? _output : null;
        }

        private bool HasRemainders(int input)
        {
            return input % _divisor == 0;
        }
    }

    public class DefaultRules
    {
        public static RuleConverter[] Rules => new RuleConverter[] { new Fizzer(), new Buzzer(), new Popper() };
    }

    public class Fizzer : RuleConverter
    {
        public Fizzer() : base("Fizz", 3)
        {
        }
    }

    public class Buzzer : RuleConverter
    {
        public Buzzer() : base("Buzz", 5)
        {
        }
    }

    public class Popper : RuleConverter
    {
        public Popper() : base("Pop", 7)
        {
        }
    }

    public class Converter
    {
        private readonly RuleConverter[] _rules;

        public Converter() : this(DefaultRules.Rules)
        {
        }

        public Converter(RuleConverter customRule) : this(new[] { customRule })
        {
        }

        public Converter(IEnumerable<RuleConverter> customRules)
        {
            _rules = customRules.ToArray();
        }

        public string Convert(int input)
        {
            return ConvertUsingRules(input) ?? input.ToString();
        }

        private string ConvertUsingRules(int input)
        {
            return AggregateRules(input).DefaultIfNull();
        }

        private string AggregateRules(int input)
        {
            return _rules.Select(x => x.GetOutput(input)).Aggregate("", string.Concat);
        }
    }
}
