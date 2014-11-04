using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Logic.Entities;


namespace Logic.Readers
{
    public class RssReader : IReader
    {
        public List<FeedItem> Read(string url)
        {

            List<FeedItem> rssFlow = new List<FeedItem>();


            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();


            foreach (SyndicationItem item in feed.Items)
            {
                var feedItem = new FeedItem();

                feedItem.Id = item.Id;
                feedItem.Title = item.Title.Text;
                feedItem.Link = item.Links.LastOrDefault().GetAbsoluteUri().ToString();
                feedItem.Date = item.PublishDate.ToString();
                feedItem.Uppspelad = "Nej";

                rssFlow.Add(feedItem);


            }
            return rssFlow.ToList();
        }

        public async Task UpdateFeedsWithSelectedUrl(string url)
        {
            var xmlReader = XmlReader.Create(url, new XmlReaderSettings() {Async = true});
            XDocument xdocu = XDocument.Load("Feed.xml");

            await xmlReader.ReadAsync();

            var feeds = SyndicationFeed.Load(xmlReader);
            var biggestDate = new DateTime(1994, 11, 02);

            var feed = xdocu.Descendants("Feed").Single(c => c.Element("Url").Value == url);
            var dates = feed.Descendants("FeedItem").Select(i => i.Element("Date").Value).ToList();

            foreach (var node in dates)
            {
                DateTime dateTime = DateTime.Parse(node);
                if (dateTime > biggestDate)
                {
                    biggestDate = dateTime;
                }
            }

            foreach (var v in feeds.Items)
            {
                if (v.PublishDate > biggestDate)
                {
                    var ele = new XElement(
                        "FeedItem",
                        new XElement("Id", v.Id),
                        new XElement("Link", v.Links.LastOrDefault().GetAbsoluteUri().ToString()),
                        new XElement("Date", v.PublishDate),
                        new XElement("Uppspelad", "Nej"),
                        new XElement("Title", v.Title.Text));

                    xdocu.Descendants("Feed")
                        .Where(va => va.Element("Url").Value == url)
                        .Elements("Items")
                        .Single()
                        .AddFirst(ele);
                }
            }
            xdocu.Save("Feed.xml");
        }
    }
}

                  