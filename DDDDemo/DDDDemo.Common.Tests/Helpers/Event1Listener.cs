using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;

namespace DDDDemo.Common.Tests.Helpers
{
    public class Event1Listener : IEventListener<TestEvent1>
    {
        public void Handle(TestEvent1 eventData)
        {
            //do nothing
        }
    }
}
