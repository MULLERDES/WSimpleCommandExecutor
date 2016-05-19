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
        public Status TaskStatus { get; set; } = Status.created;

        int MaxIteration = 0;
        int it = 0;
        public FakeTask()
        {
            Random r = new Random();
            MaxIteration =  r.Next(100, 1000);;
        }
        public void Start()
        {
            if (TaskStatus != Status.created)
                return;
            TaskStatus = Status.running;
            Task.Factory.StartNew(new Action(() => {
                // fake do smoething
                it = 0;
                while(TaskStatus== Status.running )
                {
                    Console.Write("tick" + MaxIteration.ToString());
                    Thread.Sleep(100);

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
    }

   

}
