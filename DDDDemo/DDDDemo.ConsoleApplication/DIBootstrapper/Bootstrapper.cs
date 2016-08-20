using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDDDemo.Common.Aspects;
using DDDDemo.Persistence;
using DDDDemo.UserManagement.Application.Users;
using Microsoft.Win32;

namespace DDDDemo.ConsoleApplication.DIBootstrapper
{
    public class Bootstrapper
    {
        public IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();
            
            //Common
            container.Register(Component.For<ILogger>().ImplementedBy<ConsoleLogger>());

            //Aspects - register all at once based on assebly 
            container.Register(Classes.FromAssemblyContaining<LoggingAspect>().BasedOn<IInterceptor>().WithServiceSelf().LifestyleTransient());

            //UserManagement
            container.Register(Component.For<UserManagement.Domain.Interfaces.IUserRepository>().
                ImplementedBy<UserManagement.Infrastructure.Persistence.Users.UserRepository>());


            //InvoicingModule
            container.Register(Component.For<InvoicingModule.Domain.Interfaces.IUserRepository>()
                .ImplementedBy<InvoicingModule.Infrastructure.Persistence.Users.UserRepository>());

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>()
                .Interceptors(
                    InterceptorReference.ForType<LoggingAspect>(),
                    InterceptorReference.ForType<ExceptionHandlingAspect>()).First);

            //DBMock
            container.Register(Component.For<DbContext>().LifeStyle.Singleton.Start());

            return container;
        }
    }
}
