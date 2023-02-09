namespace AllowanceExtractor.Function;

public class Allowance
{
    public string Country { get; set; } = string.Empty;

    public string CountryCode { get; set; } = string.Empty;

    public string CurrencyCode { get; set; } = string.Empty;

    public decimal FixedAllowance { get; set; }

    public decimal GeographicAllowance { get; set; }
}