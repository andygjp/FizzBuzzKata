namespace FizzBuzz
{
    internal static class StringExtension
    {
        public static string DefaultIfNull(this string value)
        {
            return value.Length == 0 ? null : value;
        }
    }
}