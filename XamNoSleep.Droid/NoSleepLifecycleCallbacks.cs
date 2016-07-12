using Acr.Support.Android;
using Android.App;

namespace XamNoSleep
{
    public class NoSleepLifecycleCallbacks : ActivityLifecycleCallbacks
    {
        public new static void Register(Activity activity)
        {
            NoSleepLifecycleCallbacks.Register(activity.Application);
            NoSleepLifecycleCallbacks.CurrentTopActivity = activity;
        }

        public new static void Register(Application app)
        {
            app.RegisterActivityLifecycleCallbacks(new NoSleepLifecycleCallbacks());
        }

        public override void OnActivityResumed(Activity activity)
        {
            base.OnActivityResumed(activity);
            var instance = NoSleepService.Instance as NoSleep;
            instance.AssessNoSleep();
        }
    }
}