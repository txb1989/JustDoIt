using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OwinStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions();
            //服务器Url设置
            options.Urls.Add("http://localhost:9000");
            options.Urls.Add("http://192.168.2.12:8080");
            //Server实现类库设置
            options.ServerFactory = "Microsoft.Owin.Host.HttpListener";
            using (WebApp.Start(options, Startup))
            {
                Console.WriteLine("Owin Host/Server started,press enter to exit it...");
                Console.ReadLine();
            }
        }

        private static void Startup(Owin.IAppBuilder app)
        {
            //这里通过app句柄,为当前Server加入所有需要的middleware
            Console.WriteLine("Sample Middleware loaded...");
            app.Use<SampleMiddleware>();
        }
    }
}
