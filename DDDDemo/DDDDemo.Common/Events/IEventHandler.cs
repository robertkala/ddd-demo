using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public interface IEventHandler
    { }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : class
    {
        void Handle(TEvent eventData);
    }
}
