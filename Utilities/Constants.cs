using System.Collections.Generic;

namespace AllowanceExtractor.Function;

public static class Datas
{
    public class CountryInfos
    {
        public string CurrencyCode { get; set; }
        public string Icon { get; set; }

        public CountryInfos(string currencyCode, string icon)
        {
            this.CurrencyCode = currencyCode;
            this.Icon = icon;
        }
    }

    public static readonly Dictionary<int, CountryInfos> CountriesInfos = new Dictionary<int, CountryInfos>
    {
        {10, new CountryInfos("AFN", "fi fi-af")}, //AFGHANISTAN
        {931, new CountryInfos("ZAR", "fi fi-za")}, //AFRIQUE DU SUD (AUTRES VILLES)
        {930, new CountryInfos("ZAR", "fi fi-za")}, //AFRIQUE DU SUD (JOHANNESBURG, PRETORIA)
        {15, new CountryInfos("ALL", "fi fi-al")}, //ALBANIE
        {21, new CountryInfos("DZD", "fi fi-dz")}, //ALGERIE (ANNABA, CONSTANTINE)
        {20, new CountryInfos("DZD", "fi fi-dz")}, //ALGERIE (AUTRES VILLES)
        {25, new CountryInfos("EUR", "fi fi-de")}, //ALLEMAGNE (AUTRES VILLES)
        {33, new CountryInfos("EUR", "fi fi-de")}, //ALLEMAGNE (BERLIN)
        {22, new CountryInfos("EUR", "fi fi-de")}, //ALLEMAGNE (HAMBOURG)
        {30, new CountryInfos("EUR", "fi fi-ad")}, //ANDORRE
        {35, new CountryInfos("AOA", "fi fi-ao")}, //ANGOLA
        {38, new CountryInfos("XCD", "fi fi-ag")}, //ANTIGUA-ET-BARBUDA
        {40, new CountryInfos("SAR", "fi fi-sa")}, //ARABIE SAOUDITE
        {45, new CountryInfos("ARS", "fi fi-ar")}, //ARGENTINE
        {46, new CountryInfos("AMD", "fi fi-am")}, //ARMENIE
        {50, new CountryInfos("AUD", "fi fi-au")}, //AUSTRALIE (AUTRES VILLES)
        {51, new CountryInfos("AUD", "fi fi-au")}, //AUSTRALIE (SYDNEY)
        {55, new CountryInfos("EUR", "fi fi-at")}, //AUTRICHE
        {60, new CountryInfos("AZN", "fi fi-az")}, //AZERBAIDJAN
        {70, new CountryInfos("BHD", "fi fi-bh")}, //BAHREIN
        {75, new CountryInfos("BDT", "fi fi-bd")}, //BANGLADESH
        {510, new CountryInfos("BBD", "fi fi-bb")}, //BARBADE
        {85, new CountryInfos("EUR", "fi fi-be")}, //BELGIQUE
        {86, new CountryInfos("BZD", "fi fi-bz")}, //BELIZE
        {240, new CountryInfos("XOF", "fi fi-bj")}, //BENIN
        {89, new CountryInfos("INR", "fi fi-bt")}, //BHOUTAN
        {92, new CountryInfos("BYN", "fi fi-by")}, //BIELORUSSIE
        {90, new CountryInfos("MMK", "fi fi-mm")}, //BIRMANIE
        {95, new CountryInfos("BOB", "fi fi-bo")}, //BOLIVIE
        {96, new CountryInfos("BAM", "fi fi-ba")}, //BOSNIE-HERZEGOVINE
        {97, new CountryInfos("BWP", "fi fi-bw")}, //BOTSWANA
        {102, new CountryInfos("BRL", "fi fi-br")}, //BRESIL (AUTRES VILLES)
        {101, new CountryInfos("BRL", "fi fi-br")}, //BRESIL (BRASILIA)
        {106, new CountryInfos("BRL", "fi fi-br")}, //BRESIL (RIO DE JANEIRO)
        {104, new CountryInfos("BRL", "fi fi-br")}, //BRESIL (SAO PAULO)
        {105, new CountryInfos("BND", "fi fi-bn")}, //BRUNEI
        {110, new CountryInfos("BGN", "fi fi-bg")}, //BULGARIE
        {760, new CountryInfos("XOF", "fi fi-bf")}, //BURKINA FASO
        {115, new CountryInfos("BIF", "fi fi-bi")}, //BURUNDI
        {329, new CountryInfos("KYD", "fi fi-ky")}, //CAIMANS
        {140, new CountryInfos("KHR", "fi fi-kh")}, //CAMBODGE
        {145, new CountryInfos("XOF", "fi fi-cm")},//CAMEROUN (AUTRES VILLES)
        {146, new CountryInfos("XOF", "fi fi-cm")}, //CAMEROUN (DOUALA, GAROUA)
        {150, new CountryInfos("CAD", "fi fi-ca")}, //CANADA (AUTRES VILLES FRANCOPHONES)
        {156, new CountryInfos("CAD", "fi fi-ca")}, //CANADA (OTTAWA)
        {151, new CountryInfos("CAD", "fi fi-ca")}, //CANADA (TORONTO ET AUTRES VILLES ANGLOPHONES)
        {152, new CountryInfos("CAD", "fi fi-ca")}, //CANADA (VANCOUVER)
        {153, new CountryInfos("CVE", "fi fi-cv")}, //CAP-VERT
        {165, new CountryInfos("CLP", "fi fi-cl")}, //CHILI
        {172, new CountryInfos("CNY", "fi fi-cn")}, //CHINE (CANTON, WUHAN)
        {173, new CountryInfos("HKD", "fi fi-cn")}, //CHINE (HONG-KONG)
        {385, new CountryInfos("RMB", "fi fi-cn")}, //CHINE (CHENGDU, SHENYANG, AUTRES VILLES)
        {170, new CountryInfos("RMB", "fi fi-cn")}, //CHINE (PEKIN)
        {171, new CountryInfos("RMB", "fi fi-cn")}, //CHINE (SHANGHAI)
        {175, new CountryInfos("EUR", "fi fi-cy")}, //CHYPRE
        {185, new CountryInfos("COP", "fi fi-co")}, //COLOMBIE
        {187, new CountryInfos("KMF", "fi fi-km")}, //COMORES
        {190, new CountryInfos("CDF", "fi fi-cd")}, //CONGO
        {196, new CountryInfos("CDF", "fi fi-cd")}, //CONGO RDC (AUTRES VILLES)
        {195, new CountryInfos("CDF", "fi fi-cd")}, //CONGO RDC (KINSHASA)
        {200, new CountryInfos("KRW", "fi fi-kr")}, //COREE DU SUD
        {205, new CountryInfos("CRC", "fi fi-cr")}, //COSTA RICA
        {210, new CountryInfos("XOF", "fi fi-ci")}, //COTE D'IVOIRE
        {230, new CountryInfos("EUR", "fi fi-hr")}, //CROATIE
        {215, new CountryInfos("CUP", "fi fi-cu")}, //CUBA
        {245, new CountryInfos("DKK", "fi fi-dk")}, //DANEMARK
        {754, new CountryInfos("DJF", "fi fi-dj")}, //DJIBOUTI
        {515, new CountryInfos("XCD", "fi fi-dm")}, //DOMINIQUE
        {750, new CountryInfos("EGP", "fi fi-eg")}, //EGYPTE
        {3, new CountryInfos("AED", "fi fi-ae")}, //EMIRATS ARABES UNIS (ABU-DAHBI)
        {11, new CountryInfos("AED", "fi fi-ae")}, //EMIRATS ARABES UNIS (AUTRES VILLES)
        {260, new CountryInfos("USD", "fi fi-ec")}, //EQUATEUR
        {262, new CountryInfos("ERN", "fi fi-er")}, //ERYTHREE
        {265, new CountryInfos("EUR", "fi fi-es")}, //ESPAGNE
        {294, new CountryInfos("EUR", "fi fi-ee")}, //ESTONIE
        {860, new CountryInfos("ZAR", "fi fi-sz")}, //ESWATINI
        {274, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (AUTRES VILLES)
        {451, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (CALIFORNIA)
        {455, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (MIAMI, WASH, BOSTON,CHICAGO)
        {273, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (NEW-YORK DOWNTOWN)
        {457, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (NY METROPOLITAN)
        {456, new CountryInfos("USD", "fi fi-us")}, //ETATS-UNIS (PENNSYLVANIE)
        {275, new CountryInfos("ETB", "fi fi-et")}, //ETHIOPIE
        {280, new CountryInfos("FJD", "fi fi-fj")}, //FIDJI
        {290, new CountryInfos("EUR", "fi fi-fi")}, //FINLANDE
        {311, new CountryInfos("XOF", "fi fi-ga")}, //GABON (AUTRES VILLES)
        {310, new CountryInfos("XOF", "fi fi-ga")}, //GABON (LIBREVILLE)
        {312, new CountryInfos("GMD", "fi fi-gm")}, //GAMBIE
        {314, new CountryInfos("GEL", "fi fi-ge")}, //GEORGIE 
        {315, new CountryInfos("GHS", "fi fi-gh")}, //GHANA 
        {330, new CountryInfos("EUR", "fi fi-gr")}, //GRECE 
        {333, new CountryInfos("XCD", "fi fi-gd")}, //GRENADE 
        {335, new CountryInfos("GTQ", "fi fi-gt")}, //GUATEMALA 
        {340, new CountryInfos("GNF", "fi fi-gn")}, //GUINEE 
        {343, new CountryInfos("XOF", "fi fi-gq")}, //GUINEE EQUATORIALE 
        {345, new CountryInfos("XOF", "fi fi-gw")}, //GUINEE-BISSAO 
        {350, new CountryInfos("GYD", "fi fi-gy")}, //GUYANA 
        {375, new CountryInfos("HTG", "fi fi-ht")}, //HAITI 
        {380, new CountryInfos("HNL", "fi fi-hn")}, //HONDURAS 
        {390, new CountryInfos("HUF", "fi fi-hu")}, //HONGRIE 
        {410, new CountryInfos("INR", "fi fi-in")}, //INDE (AUTRES VILLES) 
        {413, new CountryInfos("INR", "fi fi-in")}, //INDE (BANGALORE) 
        {411, new CountryInfos("INR", "fi fi-in")}, //INDE (BOMBAY, CALCUTTA) 
        {412, new CountryInfos("INR", "fi fi-in")}, //INDE (NEW DELHI) 
        {415, new CountryInfos("IDR", "fi fi-id")}, //INDONESIE 
        {420, new CountryInfos("IQD", "fi fi-iq")}, //IRAK (AUTRES VILLES)
        {421, new CountryInfos("IQD", "fi fi-iq")}, //IRAK (ERBIL)
        {425, new CountryInfos("IRR", "fi fi-ir")}, //IRAN
        {430, new CountryInfos("EUR", "fi fi-ie")}, //IRLANDE
        {435, new CountryInfos("ISK", "fi fi-is")}, //ISLANDE
        {440, new CountryInfos("ILS", "fi fi-il")}, //ISRAEL
        {445, new CountryInfos("EUR", "fi fi-it")}, //ITALIE (AUTRES VILLES)
        {449, new CountryInfos("EUR", "fi fi-it")}, //ITALIE (TURIN)
        {470, new CountryInfos("JMD", "fi fi-jm")}, //JAMAIQUE
        {476, new CountryInfos("JPY", "fi fi-jp")}, //JAPON (AUTRES VILLES)
        {475, new CountryInfos("JPY", "fi fi-jp")}, //JAPON (TOKYO)
        {441, new CountryInfos("ILS", "fi fi-il")}, //JERUSALEM
        {485, new CountryInfos("JOD", "fi fi-jo")}, //JORDANIE
        {495, new CountryInfos("KZT", "fi fi-kz")}, //KAZAKHSTAN (AUTRES VILLES)
        {496, new CountryInfos("KZT", "fi fi-kz")}, //KAZAKHSTAN (NOURSOULTAN)
        {500, new CountryInfos("KES", "fi fi-ke")}, //KENYA
        {502, new CountryInfos("KGS", "fi fi-kg")}, //KIRGHIZSTAN
        {981, new CountryInfos("EUR", "fi fi-xk")}, //KOSOVO
        {505, new CountryInfos("KWD", "fi fi-kw")}, //KOWEIT
        {520, new CountryInfos("LAK", "fi fi-la")}, //LAOS
        {522, new CountryInfos("LSL", "fi fi-ls")}, //LESOTHO
        {523, new CountryInfos("EUR", "fi fi-lv")}, //LETTONIE
        {525, new CountryInfos("LBP", "fi fi-lb")}, //LIBAN
        {530, new CountryInfos("LRD", "fi fi-lr")}, //LIBERIA
        {535, new CountryInfos("LYD", "fi fi-ly")}, //LIBYE
        {538, new CountryInfos("EUR", "fi fi-lt")}, //LITUANIE
        {540, new CountryInfos("EUR", "fi fi-lu")}, //LUXEMBOURG
        {545, new CountryInfos("MOP", "fi fi-mo")}, //MACAO
        {555, new CountryInfos("MKD", "fi fi-mk")}, //MACEDOINE
        {560, new CountryInfos("MGA", "fi fi-mg")}, //MADAGASCAR
        {565, new CountryInfos("MYR", "fi fi-my")}, //MALAISIE
        {570, new CountryInfos("MWK", "fi fi-mw")}, //MALAWI
        {573, new CountryInfos("MVR", "fi fi-mv")}, //MALDIVES
        {575, new CountryInfos("XOF", "fi fi-ml")}, //MALI
        {580, new CountryInfos("EUR", "fi fi-mt")}, //MALTE
        {589, new CountryInfos("MAD", "fi fi-ma")}, //MAROC (AGADIR)
        {585, new CountryInfos("MAD", "fi fi-ma")}, //MAROC (AUTRES VILLES)
        {405, new CountryInfos("MUR", "fi fi-mu")}, //MAURICE
        {590, new CountryInfos("MRU", "fi fi-mr")}, //MAURITANIE
        {601, new CountryInfos("MXN", "fi fi-mx")}, //MEXIQUE (AUTRES VILLES)
        {600, new CountryInfos("MXN", "fi fi-mx")}, //MEXIQUE (MEXICO)
        {606, new CountryInfos("MDL", "fi fi-md")}, //MOLDAVIE
        {605, new CountryInfos("EUR", "fi fi-mc")}, //MONACO
        {607, new CountryInfos("MNT", "fi fi-mn")}, //MONGOLIE
        {985, new CountryInfos("EUR", "fi fi-me")}, //MONTENEGRO
        {610, new CountryInfos("MZN", "fi fi-mz")}, //MOZAMBIQUE
        {620, new CountryInfos("ZAR", "fi fi-na")}, //NAMIBIE
        {630, new CountryInfos("NPR", "fi fi-np")}, //NEPAL
        {640, new CountryInfos("NIO", "fi fi-ni")}, //NICARAGUA
        {645, new CountryInfos("XOF", "fi fi-ne")}, //NIGER
        {650, new CountryInfos("XOF", "fi fi-ne")}, //NIGERIA (AUTRES VILLES)
        {651, new CountryInfos("XOF", "fi fi-ne")}, //NIGERIA (LAGOS)
        {660, new CountryInfos("NOK", "fi fi-no")}, //NORVEGE (AUTRES VILLES)
        {662, new CountryInfos("NOK", "fi fi-no")}, //NORVEGE (STAVANGER)
        {655, new CountryInfos("NZD", "fi fi-nz")}, //NOUVELLE-ZELANDE
        {670, new CountryInfos("OMR", "fi fi-om")}, //OMAN
        {675, new CountryInfos("UGX", "fi fi-ug")}, //OUGANDA
        {680, new CountryInfos("UZS", "fi fi-uz")}, //OUZBEKISTAN
        {685, new CountryInfos("PKR", "fi fi-pk")}, //PAKISTAN (AUTRES VILLES)
        {686, new CountryInfos("PKR", "fi fi-pk")}, //PAKISTAN (KARACHI)
        {690, new CountryInfos("USD", "fi fi-pa")}, //PANAMA
        {653, new CountryInfos("PGK", "fi fi-pg")}, //PAPOUASIE-NOUVELLE-GUINEE
        {695, new CountryInfos("PYG", "fi fi-py")}, //PARAGUAY
        {700, new CountryInfos("EUR", "fi fi-nl")}, //PAYS-BAS
        {705, new CountryInfos("PEN", "fi fi-pe")}, //PEROU
        {710, new CountryInfos("PHP", "fi fi-ph")}, //PHILIPPINES
        {715, new CountryInfos("PLN", "fi fi-pl")}, //POLOGNE
        {725, new CountryInfos("EUR", "fi fi-pt")}, //PORTUGAL
        {727, new CountryInfos("QAR", "fi fi-qa")}, //QATAR
        {155, new CountryInfos("XOF", "fi fi-cf")}, //REPUBLIQUE CENTRAFRICAINE
        {755, new CountryInfos("DOP", "fi fi-do")}, //REPUBLIQUE DOMINICAINE
        {93, new CountryInfos("CZK", "fi fi-cz")}, //REPUBLIQUE TCHEQUE
        {770, new CountryInfos("RON", "fi fi-ro")}, //ROUMANIE
        {326, new CountryInfos("GBP", "fi fi-uk")}, //ROYAUME-UNI (AUTRES VILLES)
        {325, new CountryInfos("GBP", "fi fi-uk")}, //ROYAUME-UNI (EDIMBOURG)
        {327, new CountryInfos("GBP", "fi fi-uk")}, //ROYAUME-UNI (LONDRES)
        {780, new CountryInfos("GBP", "fi fi-uk")}, //ROYAUME-UNI (SAINTE-HELENE)
        {938, new CountryInfos("RUB", "fi fi-ru")}, //RUSSIE (AUTRES VILLES)
        {935, new CountryInfos("RUB", "fi fi-ru")}, //RUSSIE (MOSCOU)
        {936, new CountryInfos("RUB", "fi fi-ru")}, //RUSSIE (SAINT-PETERSBOURG)
        {775, new CountryInfos("RWF", "fi fi-rw")}, //RWANDA
        {783, new CountryInfos("XCD", "fi fi-kn")}, //SAINT-CHRISTOPHE-ET-NIEVES
        {785, new CountryInfos("XCD", "fi fi-lc")}, //SAINTE-LUCIE
        {701, new CountryInfos("ANG", "fi fi-mf")}, //SAINT-MARTIN
        {800, new CountryInfos("EUR", "fi fi-va")}, //SAINT-SIEGE
        {801, new CountryInfos("XCD", "fi fi-vc")}, //SAINT-VINCENT-ET-LES GRENADINES
        {805, new CountryInfos("USD", "fi fi-sv")}, //SALVADOR
        {803, new CountryInfos("STD", "fi fi-st")}, //SAO TOME-ET-PRINCIPE
        {810, new CountryInfos("XOF", "fi fi-sn")}, //SENEGAL
        {980, new CountryInfos("RSD", "fi fi-rs")}, //SERBIE
        {407, new CountryInfos("SCR", "fi fi-sc")}, //SEYCHELLES
        {815, new CountryInfos("SLL", "fi fi-sl")}, //SIERRA LEONE
        {820, new CountryInfos("SGD", "fi fi-sg")}, //SINGAPOUR
        {881, new CountryInfos("EUR", "fi fi-sk")}, //SLOVAQUIE
        {822, new CountryInfos("EUR", "fi fi-si")}, //SLOVENIE
        {825, new CountryInfos("USD", "fi fi-so")}, //SOMALIE
        {830, new CountryInfos("SDG", "fi fi-sd")}, //SOUDAN
        {831, new CountryInfos("SDG", "fi fi-ss")}, //SOUDAN DU SUD
        {160, new CountryInfos("LKR", "fi fi-lk")}, //SRI LANKA
        {835, new CountryInfos("SEK", "fi fi-se")}, //SUEDE
        {838, new CountryInfos("CHF", "fi fi-ch")}, //SUISSE (AUTRES VILLES)
        {840, new CountryInfos("CHF", "fi fi-ch")}, //SUISSE (GENEVE)
        {841, new CountryInfos("CHF", "fi fi-ch")}, //SUISSE (ZURICH)
        {842, new CountryInfos("SRD", "fi fi-sr")}, //SURINAME
        {845, new CountryInfos("SYP", "fi fi-sy")}, //SYRIE
        {862, new CountryInfos("TJS", "fi fi-tj")}, //TADJIKISTAN
        {865, new CountryInfos("TWD", "fi fi-tw")}, //TAIPEI
        {870, new CountryInfos("TZS", "fi fi-tz")}, //TANZANIE
        {875, new CountryInfos("XOF", "fi fi-td")}, //TCHAD
        {885, new CountryInfos("THB", "fi fi-th")}, //THAILANDE
        {887, new CountryInfos("USD", "fi fi-tl")}, //TIMOR ORIENTAL
        {890, new CountryInfos("XOF", "fi fi-tg")}, //TOGO
        {895, new CountryInfos("TTD", "fi fi-tt")}, //TRINITE-ET-TOBAGO
        {900, new CountryInfos("TND", "fi fi-tn")}, //TUNISIE
        {902, new CountryInfos("TMT", "fi fi-tm")}, //TURKMENISTAN
        {906, new CountryInfos("TRY", "fi fi-tr")}, //TURQUIE (ANKARA)
        {907, new CountryInfos("TRY", "fi fi-tr")}, //TURQUIE (AUTRES VILLES)
        {908, new CountryInfos("TRY", "fi fi-tr")}, //TURQUIE (IZMIR)
        {932, new CountryInfos("UAH", "fi fi-ua")}, //UKRAINE
        {940, new CountryInfos("UYU", "fi fi-uy")}, //URUGUAY
        {945, new CountryInfos("VUV", "fi fi-vu")}, //VANUATU
        {950, new CountryInfos("VEF", "fi fi-ve")}, //VENEZUELA
        {955, new CountryInfos("VND", "fi fi-vn")}, //VIETNAM
        {753, new CountryInfos("YER", "fi fi-ye")}, //YEMEN
        {990, new CountryInfos("ZMW", "fi fi-zm")}, //ZAMBIE
        {765, new CountryInfos("USD", "fi fi-zw")}, //ZIMBABWE
    };
}