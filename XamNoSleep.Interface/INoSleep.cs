using System;

namespace XamNoSleep
{
    public interface INoSleep
    {
        bool AllowSleep { get; set; }
        IDisposable StayAwakeDuring();
    }
}
