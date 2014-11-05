using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Navigation;
using System.Xml;
using Logic.Entities;

namespace Logic.Readers
{
    internal class asynchRssReader
    {
        public  async Task<List<FeedItem>> GetFeedsAsync(string url)
        {
           
            var httpclient = new HttpClient();
            return null;
        }
        
    }
}
