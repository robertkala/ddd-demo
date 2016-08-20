using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;

namespace DDDDemo.SharedKernel.Events
{
    public class UserCreatedEvent : IEvent
    {
        public int UserId { get; private set; }

        public UserCreatedEvent(int userId)
        {
            UserId = userId;

        }
    }
}
