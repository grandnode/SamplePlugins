﻿using Autofac;
using Grand.Core.Configuration;
using Grand.Core.Infrastructure;
using Grand.Core.Infrastructure.DependencyManagement;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, GrandConfig config)
        {
            builder.RegisterType<ExampleWidget>().InstancePerLifetimeScope();
        }

        public int Order {
            get { return 1; }
        }
    }
}
