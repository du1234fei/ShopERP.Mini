
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ConsulAndOcelot.ApiGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { /* Configuration */ });

            //添加 Ocelot 并添加配置文件
            builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);

            //使用 Ocelot 接管代码
            builder.Services.AddOcelot(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseOcelot();

            app.Run();

        }
    }
}
