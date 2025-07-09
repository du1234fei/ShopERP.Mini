
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

            //��� Ocelot ����������ļ�
            builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);

            builder.Services.AddOcelot(builder.Configuration);//ʹ�� Ocelot �ӹܴ���

            var app = builder.Build();

            //���� Ocelot �м��
            await app.UseOcelot();

            app.Run();
        }
    }
}