using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public interface IEventSubscriber
    {
        void Subscribe(IEventListener listener);
        void Unsubscribe(IEventListener listener);
    }

    public static class ReflectionHelper
    {
        public static bool IsEventListener(this Type type)
        {
            return type.IsDefined(typeof(EventListenersAttribute), true);
        }
    }
}
