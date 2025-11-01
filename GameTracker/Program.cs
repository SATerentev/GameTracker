using GameTracker.DIConnections;
using GameTracker.Infrastructure;
using GameTracker.Infrastructure.Middleware;
using GameTracker.Interfaces;
using GameTracker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

namespace GameTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.ExpireTimeSpan = TimeSpan.FromDays(365);
                });

            builder.Services.AddAuthorization();
            AccountSystem.ConnectSystem(builder);
            builder.Services.AddScoped<IHashPasswordService, HashService>();
            builder.Services.AddScoped<ICodeGenerator, CodeGenerator>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IEmailSender, DEBUG_EmailSender>();
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapStaticAssets();
            StaticWebAssetsLoader.UseStaticWebAssets(app.Environment, app.Configuration);
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.UseMiddleware<DeletedAccountRedirectMiddleware>();

            app.Run();
        }
    }
}
