using System.Collections.Generic;

namespace AllowanceExtractor.Function;

public static class AllowanceScrapping
{
    public const string ALLOWANCE_URL = "https://mon-vie-via.businessfrance.fr/indemnite-vie";
    public const string ALLOWANCE_INFOS_PATTERN = @"^([A-Z\-'\s(,)]+) (\d{0,3})\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])";
    public const int ALLOWANCE_INFOS_PATTERN_GROUP_COUNT = 6;
}

public static class Datas
{
    public static readonly Dictionary<string, string> CountriesCurrencyCode = new Dictionary<string, string>
    {
        {"AFGHANISTAN", "AFN"},
        {"AFRIQUE DU SUD (AUTRES VILLES)", "ZAR"},
        {"AFRIQUE DU SUD (JOHANNESBURG, PRETORIA)", "ZAR"},
        {"ALBANIE", "ALL"},
        {"ALGERIE (ANNABA, CONSTANTINE)", "DZD"},
        {"ALGERIE (AUTRES VILLES)", "DZD"},
        {"ALLEMAGNE (AUTRES VILLES)", "EUR"},
        {"ALLEMAGNE (BERLIN)", "EUR"},
        {"ALLEMAGNE (HAMBOURG)", "EUR"},
        {"ANDORRE", "EUR"},
        {"ANGOLA", "AOA"},
        {"ANTIGUA-ET-BARBUDA", "XCD"},
        {"ARABIE SAOUDITE", "SAR"},
        {"ARGENTINE", "ARS"},
        {"ARMENIE", "AMD"},
        {"AUSTRALIE (AUTRES VILLES)", "AUD"},
        {"AUSTRALIE (SYDNEY)", "AUD"},
        {"AUTRICHE", "EUR"},
        {"AZERBAIDJAN", "AZN"},
        {"BAHREIN", "BHD"},
        {"BANGLADESH", "BDT"},
        {"BARBADE", "BBD"},
        {"BELGIQUE", "EUR"},
        {"BELIZE", "BZD"},
        {"BENIN", "XOF"},
        {"BHOUTAN", "INR"},
        {"BIELORUSSIE", "BYN"},
        {"BIRMANIE", "MMK"},
        {"BOLIVIE", "BOB"},
        {"BOSNIE-HERZEGOVINE", "BAM"},
        {"BOTSWANA", "BWP"},
        {"BRESIL (AUTRES VILLES)", "BRL"},
        {"BRESIL (BRASILIA)", "BRL"},
        {"BRESIL (RIO DE JANEIRO)", "BRL"},
        {"BRESIL (SAO PAULO)", "BRL"},
        {"BRUNEI", "BND"},
        {"BULGARIE", "BGN"},
        {"BURKINA FASO", "XOF"},
        {"BURUNDI", "BIF"},
        {"CAIMANS", "KYD"},
        {"CAMBODGE", "KHR"},
        {"CAMEROUN (AUTRES VILLES)", "XOF"},
        {"CAMEROUN (DOUALA, GAROUA)", "XOF"},
        {"CANADA (AUTRES VILLES FRANCOPHONES)", "CAD"},
        {"CANADA (OTTAWA)", "CAD"},
        {"CANADA (TORONTO ET AUTRES VILLES ANGLOPHONES)", "CAD"},
        {"CANADA (VANCOUVER)", "CAD"},
        {"CAP-VERT", "CVE"},
        {"CHILI", "CLP"},
        {"CHINE (CANTON, WUHAN)", "CNY"},
        {"CHINE (HONG-KONG)", "HKD"},
        {"CHINE (CHENGDU, SHENYANG, AUTRES VILLES)", "RMB"},
        {"CHINE (PEKIN)", "RMB"},
        {"CHINE (SHANGHAI)", "RMB"},
        {"CHYPRE", "EUR"},
        {"COLOMBIE", "COP"},
        {"COMORES", "KMF"},
        {"CONGO", "CDF"},
        {"CONGO RDC (AUTRES VILLES)", "CDF"},
        {"CONGO RDC (KINSHASA)", "CDF"},
        {"COREE DU SUD", "KRW"},
        {"COSTA RICA", "CRC"},
        {"COTE D'IVOIRE", "XOF"},
        {"CROATIE", "EUR"},
        {"CUBA", "CUP"},
        {"DANEMARK", "DKK"},
        {"DJIBOUTI", "DJF"},
        {"DOMINIQUE", "XCD"},
        {"EGYPTE", "EGP"},
        {"EMIRATS ARABES UNIS (ABU-DAHBI)", "AED"},
        {"EMIRATS ARABES UNIS (AUTRES VILLES)", "AED"},
        {"EQUATEUR", "USD"},
        {"ERYTHREE", "ERN"},
        {"ESPAGNE", "EUR"},
        {"ESTONIE", "EUR"},
        {"ESWATINI", "ZAR"},
        {"ETATS-UNIS (AUTRES VILLES)", "USD"},
        {"ETATS-UNIS (CALIFORNIA)", "USD"},
        {"ETATS-UNIS (MIAMI, WASH, BOSTON,CHICAGO)", "USD"},
        {"ETATS-UNIS (NEW-YORK DOWNTOWN)", "USD"},
        {"ETATS-UNIS (NY METROPOLITAN)", "USD"},
        {"ETATS-UNIS (PENNSYLVANIE)", "USD"},
        {"ETHIOPIE", "ETB"},
        {"FIDJI", "FJD"},
        {"FINLANDE", "EUR"},
        {"GABON (AUTRES VILLES)", "XOF"},
        {"GABON (LIBREVILLE)", "XOF"},
        {"GAMBIE", "GMD"},
        {"GEORGIE", "GEL"},
        {"GHANA", "GHS"},
        {"GRECE", "EUR"},
        {"GRENADE", "XCD"},
        {"GUATEMALA", "GTQ"},
        {"GUINEE", "GNF"},
        {"GUINEE EQUATORIALE", "XOF"},
        {"GUINEE-BISSAO", "XOF"},
        {"GUYANA", "GYD"},
        {"HAITI", "HTG"},
        {"HONDURAS", "HNL"},
        {"HONGRIE", "HUF"},
        {"INDE (AUTRES VILLES)", "INR"},
        {"INDE (BANGALORE)", "INR"},
        {"INDE (BOMBAY, CALCUTTA)", "INR"},
        {"INDE (NEW DELHI)", "INR"},
        {"INDONESIE", "IDR"},
        {"IRAK (AUTRES VILLES)", "IQD"},
        {"IRAK (ERBIL)", "IQD"},
        {"IRAN", "IRR"},
        {"IRLANDE", "EUR"},
        {"ISLANDE", "ISK"},
        {"ISRAEL", "ILS"},
        {"ITALIE (AUTRES VILLES)", "EUR"},
        {"ITALIE (TURIN)", "EUR"},
        {"JAMAIQUE", "JMD"},
        {"JAPON (AUTRES VILLES)", "JPY"},
        {"JAPON (TOKYO)", "JPY"},
        {"JERUSALEM", "ILS"},
        {"JORDANIE", "JOD"},
        {"KAZAKHSTAN (AUTRES VILLES)", "KZT"},
        {"KAZAKHSTAN (NOURSOULTAN)", "KZT"},
        {"KENYA", "KES"},
        {"KIRGHIZSTAN", "KGS"},
        {"KOSOVO", "EUR"},
        {"KOWEIT", "KWD"},
        {"LAOS", "LAK"},
        {"LESOTHO", "LSL"},
        {"LETTONIE", "EUR"},
        {"LIBAN", "LBP"},
        {"LIBERIA", "LRD"},
        {"LIBYE", "LYD"},
        {"LITUANIE", "EUR"},
        {"LUXEMBOURG", "EUR"},
        {"MACAO", "MOP"},
        {"MACEDOINE", "MKD"},
        {"MADAGASCAR", "MGA"},
        {"MALAISIE", "MYR"},
        {"MALAWI", "MWK"},
        {"MALDIVES", "MVR"},
        {"MALI", "XOF"},
        {"MALTE", "EUR"},
        {"MAROC (AGADIR)", "MAD"},
        {"MAROC (AUTRES VILLES)", "MAD"},
        {"MAURICE", "MUR"},
        {"MAURITANIE", "MRU"},
        {"MEXIQUE (AUTRES VILLES)", "MXN"},
        {"MEXIQUE (MEXICO)", "MXN"},
        {"MOLDAVIE", "MDL"},
        {"MONACO", "EUR"},
        {"MONGOLIE", "MNT"},
        {"MONTENEGRO", "EUR"},
        {"MOZAMBIQUE", "MZN"},
        {"NAMIBIE", "ZAR"},
        {"NEPAL", "NPR"},
        {"NICARAGUA", "NIO"},
        {"NIGER", "XOF"},
        {"NIGERIA (AUTRES VILLES)", "XOF"},
        {"NIGERIA (LAGOS)", "XOF"},
        {"NORVEGE (AUTRES VILLES)", "NOK"},
        {"NORVEGE (STAVANGER)", "NOK"},
        {"NOUVELLE-ZELANDE", "NZD"},
        {"OMAN", "OMR"},
        {"OUGANDA", "UGX"},
        {"OUZBEKISTAN", "UZS"},
        {"PAKISTAN (AUTRES VILLES)", "PKR"},
        {"PAKISTAN (KARACHI)", "PKR"},
        {"PANAMA", "USD"},
        {"PAPOUASIE-NOUVELLE-GUINEE", "PGK"},
        {"PARAGUAY", "PYG"},
        {"PAYS-BAS", "EUR"},
        {"PEROU", "PEN"},
        {"PHILIPPINES", "PHP"},
        {"POLOGNE", "PLN"},
        {"PORTUGAL", "EUR"},
        {"QATAR", "QAR"},
        {"REPUBLIQUE CENTRAFRICAINE", "XOF"},
        {"REPUBLIQUE DOMINICAINE", "DOP"},
        {"REPUBLIQUE TCHEQUE", "CZK"},
        {"ROUMANIE", "RON"},
        {"ROYAUME-UNI (AUTRES VILLES)", "GBP"},
        {"ROYAUME-UNI (EDIMBOURG)", "GBP"},
        {"ROYAUME-UNI (LONDRES)", "GBP"},
        {"ROYAUME-UNI (SAINTE-HELENE)", "GBP"},
        {"RUSSIE (AUTRES VILLES)", "RUB"},
        {"RUSSIE (MOSCOU)", "RUB"},
        {"RUSSIE (SAINT-PETERSBOURG)", "RUB"},
        {"RWANDA", "RWF"},
        {"SAINT-CHRISTOPHE-ET-NIEVES", "XCD"},
        {"SAINTE-LUCIE", "XCD"},
        {"SAINT-MARTIN", "ANG"},
        {"SAINT-SIEGE", "EUR"},
        {"SAINT-VINCENT-ET-LES GRENADINES", "XCD"},
        {"SALVADOR", "USD"},
        {"SAO TOME-ET-PRINCIPE", "STD"},
        {"SENEGAL", "XOF"},
        {"SERBIE", "RSD"},
        {"SEYCHELLES", "SCR"},
        {"SIERRA LEONE", "SLL"},
        {"SINGAPOUR", "SGD"},
        {"SLOVAQUIE", "EUR"},
        {"SLOVENIE", "EUR"},
        {"SOMALIE", "USD"},
        {"SOUDAN", "SDG"},
        {"SOUDAN DU SUD", "SDG"},
        {"SRI LANKA", "LKR"},
        {"SUEDE", "SEK"},
        {"SUISSE (AUTRES VILLES)", "CHF"},
        {"SUISSE (GENEVE)", "CHF"},
        {"SUISSE (ZURICH)", "CHF"},
        {"SURINAME", "SRD"},
        {"SYRIE", "SYP"},
        {"TADJIKISTAN", "TJS"},
        {"TAIPEI", "TWD"},
        {"TANZANIE", "TZS"},
        {"TCHAD", "XOF"},
        {"THAILANDE", "THB"},
        {"TIMOR ORIENTAL", "USD"},
        {"TOGO", "XOF"},
        {"TRINITE-ET-TOBAGO", "TTD"},
        {"TUNISIE", "TND"},
        {"TURKMENISTAN", "TMT"},
        {"TURQUIE (ANKARA)", "TRY"},
        {"TURQUIE (AUTRES VILLES)", "TRY"},
        {"TURQUIE (IZMIR)", "TRY"},
        {"UKRAINE", "UAH"},
        {"URUGUAY", "UYU"},
        {"VANUATU", "VUV"},
        {"VENEZUELA", "VEF"},
        {"VIETNAM", "VND"},
        {"YEMEN", "YER"},
        {"ZAMBIE", "ZMW"},
        {"ZIMBABWE", "USD"},
    };
}