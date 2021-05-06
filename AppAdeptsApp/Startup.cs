using AppAdeptsApp.Models;
using AppAdeptsApp.Shared;
using AppAdeptsApp.Shared.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppAdeptsApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IDateTime, SystemDateTime>();
            services.AddSingleton<IUserInfo, UserInfo>();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // makes sure that for non-essential cookies, we get the user's permission.
                options.CheckConsentNeeded = _ => true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "~/");

                endpoints.MapControllerRoute(
                    name: "Dashboard",
                    pattern: "Dashboard/Index");

                endpoints.MapControllerRoute(
                    name: "Submit",
                    pattern: "Submit/Index");

                endpoints.MapControllerRoute(
                    name: "Chat",
                    pattern: "Chat/Index");

                endpoints.MapControllerRoute(
                    name: "Edit",
                    pattern: "Edit/Index");
            });
        }
    }
}
