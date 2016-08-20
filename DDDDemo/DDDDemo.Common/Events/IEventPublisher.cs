using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IEvent;
    }
}
