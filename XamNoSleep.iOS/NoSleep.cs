using System;
using UIKit;

namespace XamNoSleep
{
    public class NoSleep : AbstractNoSleep, INoSleep
    {
        public override bool AllowSleep
        {
            get 
			{ 
				return !UIApplication.SharedApplication.IdleTimerDisabled; 
			}
            set 
			{
				UIApplication.SharedApplication.InvokeOnMainThread(() => 
				{
					UIApplication.SharedApplication.IdleTimerDisabled = !value;
				});
			}
        }
    }
}
