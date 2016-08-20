using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.ConsoleApplication.DIBootstraper;

namespace DDDDemo.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Bootstrapper().CreateContainer();
        }
    }
}
