using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    interface IDevice
    {
        event EventHandler<string> ProcessCompleted;
        //only in feature
        void Init();

    }
}
