
using Newtonsoft.Json;

namespace StockTickerSymbols.Models
{
    public class CompanyStockInfo
    {
        public CompanyStockInfo(
            string companyName,
            string stockTickerSymbol)
        {
            this.CompanyName = companyName;
            this.StockTickerSymbol = stockTickerSymbol;
        }

        [JsonProperty(PropertyName = "Company_Name")]
        public string CompanyName { get; }

        [JsonProperty(PropertyName = "Ticker")]
        public string StockTickerSymbol { get; }
    }
}
