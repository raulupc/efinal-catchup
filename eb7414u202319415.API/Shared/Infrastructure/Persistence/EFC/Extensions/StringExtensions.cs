using System.Text.RegularExpressions;

namespace eb7414u202319415.API.Shared.Infrastructure.Persistence.EFC.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return Regex.Replace(text, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}