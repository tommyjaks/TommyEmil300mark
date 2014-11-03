using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Logic.Service
{
    class IntervalHandler
    {

        public void DispatcherTimerSample()
           {

              
                        DispatcherTimer timer = new DispatcherTimer();
                       // timer.Interval = TimeSpan.FromMinutes(intervalMinutes);
                        timer.Tick += timer_Tick;
                        timer.Start();
                }

                void timer_Tick(object sender, EventArgs e)
                {
                       



                }




    }
}
