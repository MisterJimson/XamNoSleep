using System;
using UIKit;
using XamNoSleep.Interface;

namespace XamNoSleep.iOS
{
    public class NoSleep : INoSleep
    {
        public bool AllowSleep
        {
            get { return !UIApplication.SharedApplication.IdleTimerDisabled; }
            set { UIApplication.SharedApplication.IdleTimerDisabled = !value; }
        }
    }
}
