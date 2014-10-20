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
        public IEnumerable<FeedItem> Read(string url)
        {

            try
            {
                var rssFeed = new List<FeedItem>();
                //test url kommer vara (Url i txtboken i xaml.cs samt att den kommer att visas upp i vår lisa

                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    String subject = item.Title.Text;
                    String summary = item.Summary.Text;
                }

                return rssFeed;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}


           
      

        

    

    

