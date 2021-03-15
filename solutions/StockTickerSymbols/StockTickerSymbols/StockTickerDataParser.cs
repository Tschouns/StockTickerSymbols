using StockTickerSymbols.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace StockTickerSymbols
{
    public class StockTickerDataParser
    {
        public IEnumerable<CompanyStockInfo> ParseCompanyStockInfosFromHtmlString(string htmlPage)
        {
            var xml = new XmlDocument();
            xml.LoadXml(htmlPage);
            var linkNodes = this.GetLinkNodes(xml.DocumentElement);
            var companyStockInfos = linkNodes
                .Select(n =>
                {
                    var splits = n.InnerText.Split(" - ");
                    return new CompanyStockInfo(
                        companyName: splits[1].Trim(),
                        stockTickerSymbol: splits[0].Trim());
                })
                .ToList();

            return companyStockInfos;
        }

        private IEnumerable<XmlNode> GetLinkNodes(XmlNode rootNode)
        {
            if (rootNode.Name == "a")
            {
                return new[] { rootNode };
            }

            var linkNodes = new List<XmlNode>();
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                var childLinkNodes = this.GetLinkNodes(childNode);
                linkNodes.AddRange(childLinkNodes);
            }

            return linkNodes;
        }
    }
}
