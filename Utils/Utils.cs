using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class Utils
    {
        public static string RemoveSpecialCharacters(this string text)
        {
            return Regex.Replace(text.ToLower().Normalize(NormalizationForm.FormD), "[^a-zA-Z\\d\\s]", "");
        }

        public static string ToCleanUrl(this string text)
        {
            return text.ToLower().RemoveSpecialCharacters().Replace(" ", "-").Replace("--", "-");
        }
    }
}
