using System;
using Data;
using Logic.Entities;
using Logic.Readers;
using Logic.Repositories;

namespace Logic.Service.Feed
{
    public class FeedService 
    {
        RssReader feedReader = new RssReader();
        

        public void getRssItems(string url)
        {

            feedReader.Read(url);



        }

        public void save()
        {
            
        }
    }
}
