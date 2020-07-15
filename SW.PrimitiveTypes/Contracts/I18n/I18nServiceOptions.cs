using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class I18nServiceOptions
    {
        public const string ConfigurationSection = "I18n";
        public string CurrencyRatesUrl { get; set; }
        public int CurrencyRatesCacheDuration { get; set; } = 60;
        public string BaseCurrency { get; set; } = "usd";
    }
}
