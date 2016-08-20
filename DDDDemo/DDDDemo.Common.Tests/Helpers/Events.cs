using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;

namespace DDDDemo.Common.Tests.Helpers
{
    public class Event: IEvent
    {
        public int Id;
    }

    public class TestEvent1 : Event
    {
        public TestEvent1(int id)
        {
            Id = id;
        }
    }

    public class TestEvent2 : Event
    {
        public TestEvent2(int id)
        {
            Id = id;
        }
    }
}
