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
using Data;

namespace Logic.Readers
{
    public class RssReader : IReader
    {
        public IEnumerable<FeedItem> Read(string url)
        {

            IEnumerable<FeedItem> rssFlow = new List<FeedItem>();


            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            FeedItem feedItem = new FeedItem();
            foreach (SyndicationItem item in feed.Items)
            {

                
                feedItem.Title = item.Title.Text;


                foreach (var link in feed.Links)
                {
                    feedItem.Link = link.Uri.ToString();
                }
                try
                {
                   
                    return rssFlow.ToList();
                }
                catch (Exception)
                {
                 


                }
                
            }
            return rssFlow;
        }
    }
}

                  