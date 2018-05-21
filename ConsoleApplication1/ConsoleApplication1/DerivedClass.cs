using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("inside Derived class constructor");
        }
        public DerivedClass(int a):base(a, a+1)
        {
            Console.WriteLine("inside Derived class constructor with parameter" + a);
        }
    }
}
