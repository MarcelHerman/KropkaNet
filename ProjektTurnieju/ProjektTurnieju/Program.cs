using ProjektTurnieju.DBActions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ProjektTurnieju.Data;
using ProjektTurnieju.Migrations;
using ProjektTurnieju.Models;
using System.Data;

namespace ProjektTurnieju
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddDbContext<TurniejDBContext>();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthentication("CookieAuthentication")
            .AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.HttpOnly = true;
                config.Cookie.SecurePolicy = CookieSecurePolicy.None;
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/EkranLogowania";
                config.Cookie.SameSite = SameSiteMode.Strict;
            });

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Organizator");
				options.Conventions.AuthorizeFolder("/Kapitan");
			});

            builder.Services.AddScoped<DBUzytkownik>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.Run();
        }



    }
}