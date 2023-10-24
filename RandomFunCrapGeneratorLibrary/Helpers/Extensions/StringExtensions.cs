namespace RandomFunCrapGeneratorLibrary.Helpers.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsNullOrWhiteSpaceOrEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s);
        }
    }
}
