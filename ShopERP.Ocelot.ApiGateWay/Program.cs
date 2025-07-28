
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

            //�� �����֣�ע�ᵽ������
            builder.Services.AddTransient<ConsulServiceDiscover>();

            ////��� Ocelot ����������ļ�
            builder.Configuration.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true);

            //ʹ�� Ocelot �ӹܴ���
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

            //����˫·�ɣ� API (/T1) �� Ocelot ���������������� .NET8 ����
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



