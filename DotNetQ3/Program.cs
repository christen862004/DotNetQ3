using DotNetQ3.Models;
using DotNetQ3.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotNetQ3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services in IOC Container
            // Add services to the container.//Service s Day8  
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //REgister IOC Contrinaer

            //1) Built in service already register (IConfiguration)
            //2) Built in Sevice need to register
            builder.Services.AddDbContext<ITIContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });//inject constructor ITIcontext

            //3) Custom service and need regitser <--
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            #endregion
            
            var app = builder.Build();
            
            #region Custom (inline ) Middleware

            //app.Use(async (httpContext, next)=>{
            //    await httpContext.Response.WriteAsync("1) Middleware 1\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("1) Middleware 1--\n");

            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2) Middleware 2\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("2) Middleware 2--\n");

            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3) Terminate\n");

            //});

            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("4) Middleware 4\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("4) Middleware 4--\n");

            //});
            #endregion
            #region Build In Middleware
           
            // Configure the HTTP request pipeline.//Middleawre Day 2/3
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//request ==>redirect wwwroot

            app.UseSession();/*session default setting*/

            app.UseRouting();/*default middleware*/

            app.UseAuthorization();
            //order Add Route
            //app.MapControllerRoute("Route1", "t1/{age:int:max(20)}/{name?}",//2 segmat || 3 segmat
            //    new
            //    {
            //        controller="Route",
            //        action= "Test1"
            //    });
            //app.MapControllerRoute("Route2", "t2",
            //    new
            //    {
            //        controller = "Route",
            //        action = "Test2"
            //    });
            //app.MapControllerRoute("Route1", "t1/{action}",//2 segmat || 3 segmat
            //    new
            //    {
            //        controller = "Route"
            //    });
            //app.MapControllerRoute("Route1", "{controller=Employee}/{action=Index}");

            //Naming Cnofination route

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
/*
 builder
setting
build
Middleware
 
 
 */