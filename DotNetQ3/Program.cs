namespace DotNetQ3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.//Service s Day8  
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            
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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
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