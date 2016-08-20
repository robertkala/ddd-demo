using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Error(Exception exception);
    }
}
