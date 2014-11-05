using System;
using System.Collections.Generic;
using System.Linq;

using System.Timers;
using System.Windows;
using System.Xml.Linq;
using Logic.Readers;

namespace Logic.Service
{
   public class IntervalHandler
    {
       public Timer UpdateintervalTimer = new Timer();
       public List<string> ListMadeOfFeeds;
       public RssReader instanceOfRssReader;
        public int Interval;
        

        public IntervalHandler(int setUpdateInterval)
        {
             ListMadeOfFeeds  = new List<string>();
           instanceOfRssReader = new RssReader();
            Interval = setUpdateInterval;
            try
            {
                GetUpdatedListOfFeeds();
                StartUpdateIntervalTimer();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ett oväntat fel har uppstått, var snäll och kontakta din RssReader-operatör omgående. ");
            }
                
        }

        

        private async void SearchForNewFeedItems(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            for (int index = 0; index < ListMadeOfFeeds.Count; index++)
            {
                var rssUrl = ListMadeOfFeeds[index];
                await instanceOfRssReader.UpdateFeedsWithSelectedUrl(rssUrl);
            }
        }

       public void yolo()
       {
           
       }
       public void GetUpdatedListOfFeeds()
        {
            try
            {
                XDocument document = XDocument.Load("Feed.xml");

              
                ListMadeOfFeeds = document.Descendants("Feed").Where(x => x.Element("UppdateInterval").Value == Interval.ToString()).ToList().Select(y => y.Element("Url").Value).ToList(); 
                    
            }
            catch (Exception e)
            {
                MessageBox.Show("Ett oväntat fel har uppstått, var snäll och kontakta din RssReader-operatör omgående. ");
            }
                
        }
        public void StartUpdateIntervalTimer()
        {

            UpdateintervalTimer.Interval = Interval * 1000;


            UpdateintervalTimer.Elapsed += SearchForNewFeedItems;
            UpdateintervalTimer.Enabled = true;



        }

       public class IntervalUpdateValues
       {
           
           private IntervalHandler checkForNewFeedItemsInterval10 = new IntervalHandler(10);
           private IntervalHandler checkForNewFeedItemsInterval30 = new IntervalHandler(30);
           private IntervalHandler checkForNewFeedItemsInterval60 = new IntervalHandler(60);

           public void UpdateXmlFileWithSetIntervalForFile()
           {
               try
               {
                   checkForNewFeedItemsInterval10.GetUpdatedListOfFeeds();
                   checkForNewFeedItemsInterval30.GetUpdatedListOfFeeds();
                   checkForNewFeedItemsInterval60.GetUpdatedListOfFeeds();
               }
               catch (Exception)
               {
                   MessageBox.Show("Ett oväntat fel har uppstått, var snäll och kontakta din RssReader-operatör omgående. ");
                   
               }
              
                   
           }
       }



    }
}
