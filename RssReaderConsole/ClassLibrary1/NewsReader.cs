using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net;
using System.Text;
using System.IO;

namespace Services
{
    public class NewsReader
    {
        private string GetXml(string url)
        {
            string xml;
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                xml = webClient.DownloadString(url).TrimStart();
            }

            return xml;
        }

        private List<PieceOfNews> GetNewsList(string url)
        {
            string xml = GetXml(url);
            var strReader = new StringReader(xml);
            var xmlReader = XmlReader.Create(strReader);
            var feed = SyndicationFeed.Load(xmlReader);
            xmlReader.Close();

            var newsList = new List<PieceOfNews>();
            foreach (SyndicationItem item in feed.Items)
            {
                var model = new PieceOfNews
                {
                    Id = item.Id,
                    Title = item.Title.Text,
                    Summary = item.Summary.Text,
                    Categories = item.Categories
                        .Select(x => x.Name)
                        .ToList(),
                    PublishDate = item.PublishDate
                };

                newsList.Add(model);
            }

            return newsList;
        }

        public List<PieceOfNews> GetNewsFromHabr()
        {
            string url = "https://habr.com/ru/rss/all/all/";

            return GetNewsList(url);
        }

        public List<PieceOfNews> GetNewsFromInterfax()
        {
            string url = "https://www.interfax.by/news/feed";

            return GetNewsList(url);
        }

        public int GetGeneralNewsCount()
        {
            List<PieceOfNews> habrNews = GetNewsFromHabr();
            List<PieceOfNews> interfaxNews = GetNewsFromInterfax();

            return habrNews.Count + interfaxNews.Count;
        }
    }
}
