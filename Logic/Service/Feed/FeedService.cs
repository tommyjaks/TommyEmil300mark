using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;
using Logic.Readers;
using Data;
using Logic.Repositories;

namespace Logic.Service.Feed
{
    public class FeedService 
    {
        static RssReader feedReader = new RssReader();


        public static void GetRssItems(string url)
        {

            feedReader.Read(url);

        }
    }
}
