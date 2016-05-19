using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{

    public interface ITask
    {
        Status TaskStatus { get; set; }
        int Percentage { get; }
        void Start();
        void Terminate();

    }
    public enum Status
    {
        created, running, complete, aborted
    }
}
