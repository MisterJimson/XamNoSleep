using System;

namespace XamNoSleep
{
    public abstract class AbstractNoSleep : INoSleep
    {
        public abstract bool AllowSleep { get; set; }

        public IDisposable StayAwakeDuring()
        {
            return new StayAwakeDuring(this);
        }
    }
}
