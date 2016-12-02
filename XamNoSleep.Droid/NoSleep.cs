using System;
using Android.App;
using Android.Views;

namespace XamNoSleep
{
    public class NoSleep : AbstractNoSleep, INoSleep
    {
        protected internal Func<Activity> TopActivityFunc { get; set; }
        protected bool allowSleep = true;

        public NoSleep(Func<Activity> topActivityFunc)
        {
            this.TopActivityFunc = topActivityFunc;
        }

        public override bool AllowSleep
        {
            get { return allowSleep; }
            set
            {
                allowSleep = value; 
                AssessNoSleep();
            }
        }

        internal void AssessNoSleep()
        {
            Activity activity = TopActivityFunc();
            if (allowSleep)
            {
                activity.RunOnUiThread(() =>
                {
                    activity.Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
                });
            }
            else
            {
                activity.RunOnUiThread(() =>
                {
                    TopActivityFunc().Window.AddFlags(WindowManagerFlags.KeepScreenOn);
                });
            }
        }
    }
}