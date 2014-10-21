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
    internal class RssReader : IReader
    {
        public List<FeedItem> Read(string url)
        {

            try
            {
                List<FeedItem> rssFlow = new List<FeedItem>();

               
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                FeedItem feedItem = new FeedItem();
                foreach (SyndicationItem item in feed.Items)
                {
                    
                    
                    feedItem.Title = item.Title.Text;
                }
                rssFlow.Add(feedItem);
                return rssFlow;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}


           
      

        

    

    

