using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("inside Base class constructor");
        }

        public BaseClass(int a)
        {
            Console.WriteLine("inside Base class constructor with parameter" + a);
        }

        public BaseClass(int a, int b)
        {
         Console.WriteLine("inside base class constructor" + a + b);   
        }
    }
}
