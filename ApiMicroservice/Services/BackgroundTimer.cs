    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMicroservice.Services
{
    public class BackgroundTimer
    {
        private Timer timer;
        private int getDataDelay = 30000;
        public int GetDataDelay
        {
            get
            {
                return getDataDelay;
            }
            set
            {
                getDataDelay = value;
                timer?.Change(0, value);
            }
        }

        public BackgroundTimer()
        {
            timer = new Timer(null);
        }

        public void setCallback(TimerCallback callback)
        {
            timer = new Timer(callback, null, 0, GetDataDelay);
        }

    }
}
