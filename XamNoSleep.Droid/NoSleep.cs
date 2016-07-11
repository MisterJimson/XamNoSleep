using System;
using Android.App;
using Android.Views;
using XamNoSleep.Interface;

namespace XamNoSleep
{
    public class NoSleep : INoSleep
    {
        protected internal Func<Activity> TopActivityFunc { get; set; }

        public NoSleep(Func<Activity> getTopActivity)
        {
            this.TopActivityFunc = getTopActivity;
        }

        public bool AllowSleep
        {
            get { return ((TopActivityFunc().Window.Attributes.Flags & WindowManagerFlags.KeepScreenOn) != 0); }
            set
            {
                if (value)
                    TopActivityFunc().Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
                else
                    TopActivityFunc().Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            }
        }
    }
}