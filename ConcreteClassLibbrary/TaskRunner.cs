using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteClassLibbrary
{
    public  class TaskRunner:   ITaskRunner<ITask>       
    {
        private static Dictionary<String, ITask> _taskList;

        public TaskRunner()
        {
            if (_taskList==null)
            _taskList = new Dictionary<string, ITask>();
        }
        public ITask GetBytKey(object key)
        {
            return _taskList.ContainsKey(key?.ToString()) ? _taskList[key?.ToString()] : null;
        }

        public void PushAndRun(object key)
        {
            FakeTask t = new FakeTask();
            _taskList.Add(key?.ToString(), t);
            t.Start();
        }

        public void Terminate(object key)
        {
            var t = _taskList[key?.ToString()];
            t.Terminate();
        }
    }
}
