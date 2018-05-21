using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dc = new DerivedClass(1);
            Console.WriteLine("Hi");
        }
    }
}