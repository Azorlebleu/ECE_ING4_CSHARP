using System.Collections.Generic;

namespace Countries
{
    class M
    {
        public Dictionary<string, string> GetCountries()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Albania", "Tirana");
            dict.Add("Belgium", "Brussels");
            dict.Add("Bosnia and Herzegovina", "Sarajevo");
            dict.Add("Bulgaria", "Sofia");
            dict.Add("Croatia", "Zagreb");
            dict.Add("Denmark", "Copenhagen");
            dict.Add("Estonia", "Tallinn");
            dict.Add("France", "Paris");
            dict.Add("Georgia", "Tbilisi");
            dict.Add("Hungary", "Budapest");
            dict.Add("Ireland", "Dublin");
            dict.Add("Kosovo", "Pristina");
            dict.Add("Lithuania", "Vilnius");
            dict.Add("Malta", "Valletta");
            dict.Add("Moldova", "Chisinau");
            dict.Add("Montenegro", "Podgorica");
            dict.Add("North Macedonia", "Skopje");
            dict.Add("Poland", "Warsaw");
            dict.Add("Portugal", "Lisbon");
            dict.Add("Romania", "Bucharest");
            dict.Add("Serbia", "Belgrade");
            dict.Add("Slovakia", "Bratislava");
            dict.Add("Slovenia", "Ljubljana");
            dict.Add("Spain", "Madrid");
            dict.Add("Turkey", "Ankara");
            dict.Add("Ukraine", "Kyiv");
            return dict;
        }
    }
}
