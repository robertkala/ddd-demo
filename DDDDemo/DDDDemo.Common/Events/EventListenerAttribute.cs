﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Events
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EventListenerAttribute : Attribute
    {
    }
}
