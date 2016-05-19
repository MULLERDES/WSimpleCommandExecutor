using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcreteClassLibbrary
{
    public class FakeTask : ITask
    {
        public int Percentage
        {
            get
            {
                return TaskStatus == Status.running ?
                    it * 100 / MaxIteration :
                    TaskStatus == Status.complete ? 100 : 0;

            }
        }

        private string _params=string.Empty;

        public Status TaskStatus { get; set; } = Status.created;

        int MaxIteration = 0;
        int it = 0;
        public FakeTask()
        {
            Random r = new Random();
            MaxIteration =  r.Next(100, 1000);;
        }
        public void Start(Params p)
        {
            _params = $"{p.Name}  {p.Parameters}";
            if (TaskStatus == Status.running)
                return;
            TaskStatus = Status.running;
            Task.Factory.StartNew(new Action(() => {
                // fake do smoething
                it = 0;
                while(TaskStatus== Status.running )
                {
                    Console.Write("tick" + MaxIteration.ToString());
                    Thread.Sleep(60);

                    if (it++==MaxIteration)
                    TaskStatus = Status.complete;
                }
                
            }));
        }
        public void Terminate()
        {
            if (TaskStatus == Status.running)
                TaskStatus = Status.aborted;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {_params}";
        }
    }

   

}
