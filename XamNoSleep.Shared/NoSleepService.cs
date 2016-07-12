using System;

#if __ANDROID__
using Android.App;
#endif

namespace XamNoSleep
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
            if (instance == null)
            {
                throw new ArgumentException("You need to call NoSleepService.Init from your first Android activity!");
            }

            return instance;
#else
            return new NoSleep();
#endif
        });

#if __ANDROID__

        public static void Init(Activity activity)
        {
            NoSleepLifecycleCallbacks.Register(activity);
            instance = new NoSleep(() => NoSleepLifecycleCallbacks.CurrentTopActivity);
        }
#endif
    }
}
