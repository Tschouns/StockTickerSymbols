using Newtonsoft.Json;
using StockTickerSymbols.DataSource;
using System;
using System.IO;

namespace StockTickerSymbols
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var parser = new StockTickerDataParser();
            var stockTickerSymbols = parser.ParseCompanyStockInfosFromHtmlString(HtmlFiles.StockTickerSymbols);

            var serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting =Formatting.Indented,
            });
            var stringWriter = new StringWriter();
            serializer.Serialize(new JsonTextWriter(stringWriter), stockTickerSymbols);

            var stockTickerSymbolsJson = stringWriter.ToString();
            File.WriteAllText("C:\\Data\\stock ticker symbols.json", stockTickerSymbolsJson);
        }
    }
}
