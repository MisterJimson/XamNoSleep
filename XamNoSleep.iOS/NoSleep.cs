using System;
using UIKit;

namespace XamNoSleep
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
