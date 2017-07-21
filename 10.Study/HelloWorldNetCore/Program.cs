using System;

namespace HelloWorldNetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            C1 c = new C1();
            bool flag = c is C1;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        class C1
        {
            string name;
            int age;
        }
    }
}