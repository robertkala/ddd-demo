using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public class EventBrokerInProc: IEventPublisher, IEventSubscriber
    {
        private readonly Func<Type, object> _handlerInstanceCreator;
        private readonly Dictionary<string, HashSet<Type>> _handlersForEventType = new Dictionary<string, HashSet<Type>>();

        public EventBrokerInProc(Func<Type, object> handlerInstanceCreator = null)
        {
            _handlerInstanceCreator = handlerInstanceCreator ?? Activator.CreateInstance;
        }

        public void Publish<T>(T eventObject) where T : class
        {
            var eventName = eventObject.GetType().FullName;
            if (_handlersForEventType.ContainsKey(eventName))
            {
                foreach (var handlerType in _handlersForEventType[eventName])
                {
                    var handler = (IEventHandler<T>)_handlerInstanceCreator(handlerType);
                    handler.Handle(eventObject);
                }
            }
        }

        public void SubscribeHandler<TEventHandler>() where TEventHandler : IEventHandler
        {
            var handlerType = typeof(TEventHandler);

            var handledEventNames = handlerType
                        .GetInterfaces()
                        .Union(handlerType.IsInterface ? new[] { handlerType } : Enumerable.Empty<Type>())
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                        .Select(x => x.GetGenericArguments().Single())
                        .ToList();

            foreach (var handledEventName in handledEventNames)
            {
                var eventName = handledEventName.FullName;
                if (_handlersForEventType.ContainsKey(eventName))
                {
                    _handlersForEventType[eventName].Add(handlerType);
                }
                else
                {
                    _handlersForEventType[eventName] = new HashSet<Type> { handlerType };
                }
            }
        }
    }
}
