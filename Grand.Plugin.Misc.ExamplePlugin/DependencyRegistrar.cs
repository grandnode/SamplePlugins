using Autofac;
using Grand.Core.Configuration;
using Grand.Core.Infrastructure;
using Grand.Core.Infrastructure.DependencyManagement;
using Grand.Plugin.Misc.ExamplePlugin.Middleware;
using Grand.Plugin.Misc.ExamplePlugin.Services;
using Grand.Plugin.Misc.ExamplePlugin.Tasks;
using Grand.Services.Catalog;
using Grand.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, GrandConfig config)
        {
            builder.RegisterType<ExamplePlugin>().InstancePerLifetimeScope();
            builder.RegisterType<ExampleService>().As<IExampleService>().InstancePerLifetimeScope();
            builder.RegisterType<OverrideProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ExampleTask>().As<IScheduleTask>().InstancePerLifetimeScope();
        }

        public int Order {
            get { return 1; }
        }
    }
}
