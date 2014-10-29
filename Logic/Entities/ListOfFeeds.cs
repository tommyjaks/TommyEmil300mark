using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{

    public class ListOfFeeds : IEntity
    {
        public Guid Id { get; set; }
        public List<Feed> FeedList{ get; set; }

        public ListOfFeeds()
        {
            FeedList = new List<Feed>();


            }

        public void AddFeedToList(Feed feed)
        {
            FeedList.Add(feed);
        }
        }
    }

