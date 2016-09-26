using System;

namespace XamNoSleep
{
    public class StayAwakeDuring : IDisposable
    {
        private readonly INoSleep _noSleep;

        public StayAwakeDuring(INoSleep noSleep)
        {
            this._noSleep = noSleep;

            this._noSleep.AllowSleep = false;
        }

        public void Dispose()
        {
            this._noSleep.AllowSleep = true;
        }
    }
}
