using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CallContextStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Factory.StartNew(Thread1);
            Task task2 = Task.Factory.StartNew(Thread2);
            Task.WaitAll(task1, task2);
            Console.WriteLine("Main thread Has Run Over");
            Console.ReadKey();
        }

        public static void Thread1()
        {

            CallContext.LogicalSetData("Name", "Hello world");
            Task task3 = Task.Factory.StartNew(Thread3);
            task3.Wait();
            Console.WriteLine("Thread1里面取值：" + CallContext.LogicalGetData("Name"));
        }

        public static void Thread2()
        {
            Console.WriteLine("Thread2里面取值：" + CallContext.LogicalGetData("Name"));
        }

        public static void Thread3()
        {
            Console.WriteLine("Thread3里面取值：" + CallContext.LogicalGetData("Name"));
        }
    }
}
