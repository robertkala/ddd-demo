﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.ConsoleApplication.DIBootstrapper;

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
