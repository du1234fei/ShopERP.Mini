
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ShopERP.Ocelot.ApiGateWay.Infrastructure;

namespace ShopERP.Ocelot.ApiGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //将 服务发现，注册到容器中
            builder.Services.AddTransient<ConsulServiceDiscover>();

            ////添加 Ocelot 并添加配置文件
            builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);

            //使用 Ocelot 接管代码
            builder.Services.AddOcelot(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //配置双路由： API (/T1) 走 Ocelot ，其他请求正常走 .NET8 流程
            app.MapWhen(context=>context.Request.Path.StartsWithSegments("/T1"),
                subApp=>subApp.UseOcelot().GetAwaiter().GetResult());


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }

}



