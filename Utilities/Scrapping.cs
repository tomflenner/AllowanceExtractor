using HtmlAgilityPack;

namespace AllowanceExtractor.Function;

public static class AllowanceScrapping
{
    public const string ALLOWANCE_URL = "https://mon-vie-via.businessfrance.fr/indemnite-vie";
    public const string ALLOWANCE_INFOS_PATTERN = @"^([A-Z\-'\s(,)]+) (\d{0,3})\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])";
    public const int ALLOWANCE_INFOS_PATTERN_GROUP_COUNT = 6;

    public static string ScrapePdfUrl()
    {
        var web = new HtmlWeb();
        var html = web.Load(AllowanceScrapping.ALLOWANCE_URL);
        var a = html.DocumentNode.SelectSingleNode("//a[contains(text(), 'Barème V.I.E')]/@href");
        var href = a.GetAttributeValue("href", null);

        return href;
    }
}