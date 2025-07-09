
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Threading.Tasks;

namespace ConsulAndOcelot.GateWay
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //添加 Ocelot 并添加配置文件
            builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);

            builder.Services.AddOcelot(builder.Configuration);//使用 Ocelot 接管代码

            var app = builder.Build();

            //启用 Ocelot 中间件
            await app.UseOcelot();

            app.Run();
        }
    }
}