using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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

                FeedItem feedItem = new FeedItem();
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

                  