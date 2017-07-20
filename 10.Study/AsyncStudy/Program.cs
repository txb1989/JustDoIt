using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStudy
{
    class Program
    {
    //    static void Main(string[] args)
    //    {
    //        new Thread(Test) { IsBackground = false }.Start();      //.Net 在1.0的时候，就已经提供最基本的API.
    //        ThreadPool.QueueUserWorkItem(o => Test());              //线程池中取空闲线程执行委托（方法）
    //        Task.Run((Action)Test);                                 //.Net 4.0以上可用
    //        Console.WriteLine("Main Thread");
    //        Console.ReadLine();
    //    }

    //    static void Test()
    //    {
    //        Thread.Sleep(1000);
    //        Console.WriteLine("Hello World");
    //    }

    static void Main(string[] args)
    {
        Say();
            Console.WriteLine("Main Thread");    //由于Main不能使用async标记
            Console.ReadLine();
    }
    private async static void Say()
    {
        var t = TestAsync();
        Thread.Sleep(1100);                                     //主线程在执行一些任务
        Console.WriteLine("SayThread Thread");                       //主线程完成标记
        Console.WriteLine(await t);                             //await 主线程等待取异步返回结果
    }
    static async Task<string> TestAsync()
    {
            //return await Task.Run(() =>
            //{
            //    Thread.Sleep(1000);                                 //异步执行一些任务
            //    return "Hello World";                               //异步执行完成标记
            //});
           return await Task.FromResult<string>("Hello world");
    }
}
}
