using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDDDemo.Persistence;
using Microsoft.Win32;

namespace DDDDemo.ConsoleApplication.DIBootstraper
{
    public class Bootstrapper
    {
        public IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
            
            //Common
            container.Register(Component.For<ILogger>().ImplementedBy<ConsoleLogger>());


            //UserManagement
            container.Register(Component.For<UserManagement.Domain.Interfaces.IUserRepository>().ImplementedBy<UserManagement.Infrastructure.Persistence.Users.UserRepository>());


            //InvoicingModule
            container.Register(Component.For<InvoicingModule.Domain.Interfaces.IUserRepository>().ImplementedBy<InvoicingModule.Infrastructure.Persistence.Users.UserRepository>());


            //DBMock
            container.Register(Component.For<DbContext>().LifeStyle.Singleton.Start());

            return container;
        }
    }
}
