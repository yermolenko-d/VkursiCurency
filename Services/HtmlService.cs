using HtmlAgilityPack;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Services
{
    public class HtmlService : IHtmlService
    {
        private const string _url = "https://bank-ua.com/";
        
        public async Task<double> GetResult(string currencyType)
        {
            return await CallUrl(currencyType);
        }

        private async Task<double> CallUrl(string currencyType)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetStringAsync(_url);
            return ParseHtml(response, currencyType);
        }

        private double ParseHtml(string html, string currencyType)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //Receive li elements
            var coursesElements = htmlDoc.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("item list-effect js-item")).ToList();

            //Receive needed li
            var course = coursesElements.FirstOrDefault(x => x.ChildNodes
            .FirstOrDefault(a => a.InnerText == $"{currencyType}/UAH") != null);

            if (course == null)
            {
                return 0;
            }

            var result = course.Descendants("span")
                .FirstOrDefault(x => x.GetAttributeValue("class", "")
                .Contains("price-wrap js-price-sale")).InnerText;

            return double.Parse(result, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}