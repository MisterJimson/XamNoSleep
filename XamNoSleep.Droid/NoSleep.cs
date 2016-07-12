using System;
using Android.App;
using Android.Views;

namespace XamNoSleep
{
    public class NoSleep : INoSleep
    {
        protected internal Func<Activity> TopActivityFunc { get; set; }
        protected bool allowSleep;

        public NoSleep(Func<Activity> topActivityFunc)
        {
            this.TopActivityFunc = topActivityFunc;
        }

        public bool AllowSleep
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
            if (allowSleep)
            {
                TopActivityFunc().Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
            }
            else
            {
                TopActivityFunc().Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            }
        }
    }
}