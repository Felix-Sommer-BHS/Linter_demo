using System;

namespace Testing
{
    internal interface IDevice
    {
        event EventHandler<string> ProcessCompleted;

        //only in feature
        void Init();
    }
}