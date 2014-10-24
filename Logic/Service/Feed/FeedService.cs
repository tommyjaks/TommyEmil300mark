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
    class FeedService 
    {
        RssReader feedReader = new RssReader();


        private void getRssItems(string url)
        {

            feedReader.Read(url);



        }
    }
}
