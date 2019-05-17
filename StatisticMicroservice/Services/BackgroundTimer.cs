using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticMicroservice.Services
{
    public class BackgroundTimer: IDisposable
    {
        private Timer timer;
        private int getDataDelay = 15000;
        public int GetDataDelay
        {
            get
            {
                return getDataDelay / 1000;
            }
            set
            {
                getDataDelay = value * 1000;
                timer?.Change(0, value * 1000);
            }
        }

        public void SetCallback(TimerCallback callback)
        {
            timer = new Timer(callback, null, 0, getDataDelay);
        }


        public void StopTimer()
        {
            timer?.Change(Timeout.Infinite, 0);
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
