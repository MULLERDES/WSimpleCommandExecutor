﻿using Abstraction;
using Autofac;
using ConcreteClassLibbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacModules
{
    public class CommandExecutorModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<TaskRunner>().As<ITaskRunner<ITask>>();

        }
    }
}
