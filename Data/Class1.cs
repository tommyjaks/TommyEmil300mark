using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

// DET HÄR ÄR EN KOMMENTAR 
using System.Xml;

namespace Data
{
    internal class Class1
    {
        private void ParseRssFile()
        {

            //test url kommer vara (Url i txtboken i xaml.cs samt att den kommer att visas upp i vår lisa
            string url = "http://tyngreradio.libsyn.com/rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;

            }
            Console.WriteLine(feed.Title.Text);

        }
    }
}
