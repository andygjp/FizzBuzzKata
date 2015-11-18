namespace FizzBuzz
{
    internal class Fallback : IConvert
    {
        public string Convert(int input, string returnValue)
        {
            if (string.IsNullOrWhiteSpace(returnValue))
            {
                returnValue = input.ToString();
            }
            return returnValue;
        }
    }
}