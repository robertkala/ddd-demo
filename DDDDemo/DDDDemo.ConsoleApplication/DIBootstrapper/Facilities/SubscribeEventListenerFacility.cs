using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel.Facilities;
using DDDDemo.Common.Events;

namespace DDDDemo.ConsoleApplication.DIBootstrapper.Facilities
{
    public class SubscribeEventListenerFacility : AbstractFacility
    {
        public IEventSubscriber EventSubscriber { get; private set; }

        protected override void Init()
        {
            Kernel.ComponentCreated += OnComponentCreated;
            Kernel.ComponentDestroyed += OnComponentDestroyed;

            EventSubscriber = Kernel.Resolve<IEventSubscriber>();
        }

        void OnComponentDestroyed(ComponentModel model, object instance)
        {
            if (instance is IEventListener)
                EventSubscriber.Unsubscribe((IEventListener)instance);
        }

        void OnComponentCreated(ComponentModel model, object instance)
        {
            if (instance is IEventListener)
                EventSubscriber.Subscribe((IEventListener)instance);
        }
    }
}
