using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AllowanceExtractor.Function;

public class AllowanceDocument
{
    public DateTime DocumentDate { get; set; }

    public IEnumerable<Allowance> Allowances { get; set; }
}

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Allowance
{
    public string CountryName { get; set; } = string.Empty;

    public string CountryCode { get; set; } = string.Empty;

    public string CountryCurrencyCode { get; set; } = string.Empty;

    public string CountryIcon { get; set; } = string.Empty;

    public decimal FixedAllowance { get; set; }

    public decimal GeographicAllowance { get; set; }
}