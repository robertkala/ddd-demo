using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    public interface IEventListener
    {

    }

    public interface IEventListener<in TEvent> : IEventListener
    {
        void Handle(TEvent eventData);
    }
}
