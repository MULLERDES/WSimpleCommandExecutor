using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public  interface ITaskRunner<T> where T : ITask
    {
        T GetBytKey(object key);
        void PushAndRun(object key, Params p);
        void Terminate(object key);
    }
}
