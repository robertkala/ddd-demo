using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public class SimpleEventPublisher : IEventSubscriber, IEventPublisher
    {
        private HashSet<IEventListener> _eventHandlers = new HashSet<IEventListener>();
        private readonly object _sync = new object();

        public void Subscribe(IEventListener listener)
        {
            lock (_sync)
            {
                var h = new HashSet<IEventListener>(_eventHandlers) { listener };
                _eventHandlers = h;
            }
        }

        public void Unsubscribe(IEventListener listener)
        {
            lock (_sync)
            {
                var h = new HashSet<IEventListener>(_eventHandlers);
                h.Remove(listener);
                _eventHandlers = h;
            }
        }


        void IEventPublisher.Publish<T>(T applicationEvent)
        {
            PublishInternal(applicationEvent);
        }

        protected void PublishInternal<T>(T eventObject)
        {
            foreach (var handler in _eventHandlers)
            {
                if (handler is IEventListener<T>)
                {
                    ((IEventListener<T>)handler).Handle(eventObject);
                }
            }
        }
    }
}