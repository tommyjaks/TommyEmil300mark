using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
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
    }
}

                  