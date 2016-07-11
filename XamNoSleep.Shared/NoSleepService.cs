using System;
using XamNoSleep.Interface;

#if __ANDROID__
using Android.App;
using Acr.Support.Android;
using XamNoSleep.Droid;
#endif

#if __IOS__
using XamNoSleep.iOS;
#endif

namespace XamNoSleep.Shared
{
    public static class NoSleepService
    {
        private static INoSleep instance;
        public static INoSleep Instance
        {
            get { return instance ?? instanceInit.Value; }
            set { instance = value; }
        }

        private static readonly Lazy<INoSleep> instanceInit = new Lazy<INoSleep>(() => 
        {
#if PCL
            throw new ArgumentException("This is the PCL library, not the platform library.  You must install the nuget package in your main application project");
#elif __ANDROID__
            return Init((Application)Application.Context.ApplicationContext);
#else
            return new iOS.NoSleep();
#endif
        });

#if __ANDROID__

        public static NoSleep Init(Func<Activity> topActivityFactory) 
        {
            return new NoSleep(topActivityFactory);
        }

        public static NoSleep Init(Application app) 
        {
            ActivityLifecycleCallbacks.Register(app);
            return Init(() => ActivityLifecycleCallbacks.CurrentTopActivity);
        }

        public static NoSleep Init(Activity activity) 
        {
            ActivityLifecycleCallbacks.Register(activity);
            return Init(() => ActivityLifecycleCallbacks.CurrentTopActivity);
        }
#endif
    }
}
