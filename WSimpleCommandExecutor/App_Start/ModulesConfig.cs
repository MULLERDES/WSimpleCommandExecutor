using Autofac;
using Autofac.Integration.Mvc;
using AutofacModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WSimpleCommandExecutor
{
    public class ModulesConfig
    {
        public static void LoadModules()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new CommandExecutorModule());
            //builder.RegisterType<RotateClockwise>().As<IMatrixOperations>();
            //builder.RegisterType<TwoDimMatrixInitializer>().As<IMatrixInitializer>();
            //builder.RegisterType<MatrixCSV>().As<IMatrixEncoderDecoder>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
