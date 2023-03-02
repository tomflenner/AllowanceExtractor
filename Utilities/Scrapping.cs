using HtmlAgilityPack;

namespace AllowanceExtractor.Function;

public static class AllowanceScrapping
{
    public const string ALLOWANCE_URL = "https://mon-vie-via.businessfrance.fr/indemnite-vie";

    public static string ScrapePdfUrl()
    {
        var web = new HtmlWeb();
        var html = web.Load(AllowanceScrapping.ALLOWANCE_URL);
        var a = html.DocumentNode.SelectSingleNode("//a[contains(text(), 'Barème V.I.E')]/@href");
        var href = a.GetAttributeValue("href", null);

        return href;
    }
}