using System.Text;

namespace AllowanceExtractor.Function;

public static class Extensions
{
    public static string FormatValue(this string value)
    {
        if (string.IsNullOrEmpty(value)) return value;

        StringBuilder sb = new StringBuilder(value);

        sb.Replace(" ", "");
        sb.Replace("€", "");

        return sb.ToString();
    }
}