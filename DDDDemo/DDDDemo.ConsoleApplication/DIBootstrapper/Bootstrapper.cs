using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDDDemo.Common.Aspects;
using DDDDemo.Common.Events;
using DDDDemo.ConsoleApplication.DIBootstrapper.Facilities;
using DDDDemo.InvoicingModule.Application.Invoices;
using DDDDemo.Persistence;
using DDDDemo.SharedKernel;
using DDDDemo.SharedKernel.Interfaces;
using DDDDemo.UserManagement.Application.Users;
using DDDDemo.UserManagement.Domain.Users.Factories;
using Microsoft.Win32;

namespace DDDDemo.ConsoleApplication.DIBootstrapper
{
    public class Bootstrapper
    {
        public IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();

            //Common
            container.Register(Component.For<Common.Logging.ILogger>().ImplementedBy<Common.Logging.ConsoleLogger>());
            container.Register(Classes.FromAssemblyContaining<SimpleEventPublisher>()
                       .Where(x => x == typeof(SimpleEventPublisher))
                       .WithServiceAllInterfaces()
                       .LifestyleSingleton());

            //Shared Kernel
            container.Register(Component.For<IGeocodingService>().ImplementedBy<GeocodingServiceMock>());

            // Register event component listeners
            // This line resolves IEventSubscriber
            container.AddFacility<SubscribeEventListenerFacility>();

            //Aspects - register all at once based on assebly 
            container.Register(Classes.FromAssemblyContaining<LoggingAspect>().BasedOn<IInterceptor>().WithServiceSelf().LifestyleTransient());

            //UserManagement
            container.Register(Component.For<UserManagement.Domain.Interfaces.IUserRepository>().
                ImplementedBy<UserManagement.Infrastructure.Persistence.Users.UserRepository>());
            container.Register(Component.For<UserFactory>());

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>()
                .Interceptors(
                    InterceptorReference.ForType<LoggingAspect>(),
                    InterceptorReference.ForType<ExceptionHandlingAspect>()).First);

            //InvoicingModule
            container.Register(Component.For<InvoicingModule.Domain.Interfaces.IUserRepository>()
                .ImplementedBy<InvoicingModule.Infrastructure.Persistence.Users.UserRepository>());

            container.Register(Component.For<IInvoiceService>().ImplementedBy<InvoiceService>()
                .Interceptors(
                    InterceptorReference.ForType<LoggingAspect>(),
                    InterceptorReference.ForType<ExceptionHandlingAspect>()).First);

            //DBMock
            container.Register(Component.For<DbContext>().LifeStyle.Singleton.Start());

            //EventListeners
            RegisterEventListeners(container);

            return container;
        }

        private static void RegisterEventListeners(IWindsorContainer container)
        {
            //fancy way :)
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                                   .Where(l => l.IsEventListener())
                                   .WithServiceAllInterfaces()
                                   .Configure(x => x.Start())
                                   .LifestyleSingleton());
        }

        private static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;

                var uri = new UriBuilder(codeBase);

                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }
    }
}
