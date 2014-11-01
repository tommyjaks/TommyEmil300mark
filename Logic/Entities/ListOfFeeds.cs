using System;
using System.Collections.Generic;


namespace Logic.Entities
{

    public class ListOfFeeds : List
    {
        public new Guid Id { get; set; }
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

