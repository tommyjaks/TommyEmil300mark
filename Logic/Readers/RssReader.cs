using System;

using System.Collections.Generic;

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

            var feedItem = new FeedItem();
            foreach (SyndicationItem item in feed.Items)
            {

                
                feedItem.Title = item.Title.Text;


                foreach (var link in feed.Links)
                {
                    feedItem.Link = link.Uri.ToString();
                }   
                try
                {

                    rssFlow.Add(feedItem);
                }
                catch (Exception)
                {
                 


                }
                
            }
            return rssFlow;
        }
    }
}

                  