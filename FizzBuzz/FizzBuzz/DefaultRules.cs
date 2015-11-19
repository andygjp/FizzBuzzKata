namespace FizzBuzz
{
    public class DefaultRules
    {
        public static RuleConverter[] Rules => new[]
        {
            new RuleConverter("Fizz", 3),
            new RuleConverter("Buzz", 5),
            new RuleConverter("Pop", 7)
        };
    }
}