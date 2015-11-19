namespace FizzBuzz
{
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
}