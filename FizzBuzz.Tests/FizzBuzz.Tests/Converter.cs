namespace FizzBuzz
{
    using System.Collections.Generic;
    using System.Linq;

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