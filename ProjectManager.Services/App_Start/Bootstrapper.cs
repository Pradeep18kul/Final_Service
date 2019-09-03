using ProjectManager.Infrastructure.Logging;
using ProjectManager.Repositories;

namespace ProjectManager.Services.App_Start
{
    public class Bootstrapper
    {
        public static void Configure()
        {
            ObjectFactory.Container.Configure(x =>
            {
                x.AddRegistry<ServicesRegistry>();
                x.For<ILogger>().Use<TextFileLogger>().Singleton();
            });

            var log = ObjectFactory.Container.WhatDoIHave();
        }
    }
    public class ServicesRegistry : StructureMap.Registry
    {
        public ServicesRegistry()
        {
            Scan(x =>
            {
                x.Assembly("ProjectManager.Business");
                x.Assembly("ProjectManager.Infrastructure");
                x.Assembly("ProjectManager.Repositories");
                x.Assembly("ProjectManager.Services");
                x.WithDefaultConventions();
            });

            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}