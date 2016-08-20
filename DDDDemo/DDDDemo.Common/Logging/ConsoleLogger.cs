using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(Exception exception)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Exception: {0}\nStack trace: {1}", exception.Message, exception.StackTrace);
            Console.ForegroundColor = originalColor;
        }
    }
}
