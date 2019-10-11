using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LanchesWeb.Models;
using LanchesWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanchesWeb
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
            //services.AddControllersWithViews();

            services.AddDbContext<LanchesWebContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<ISnackCategoryRepository, SnackCategoryRepository>();
            services.AddTransient<ISnackRepository, SnackRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sc => ShoppingCart.GetId(sc));

            services.AddMvc(option =>
                    option.EnableEndpointRouting = false
                );

            services.AddMemoryCache();
            services.AddSession();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<LanchesWebContext>()
                .AddDefaultTokenProviders();

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
            app.UseSession();

            //app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapAreaControllerRoute(
            //        name: "Admin", 
            //        areaName:"Admin", 
            //        pattern:"{area:exists}/{controller=Admin}/{Action=Index}/{id?}"); 

            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapControllerRoute(
            //        name: "filterSnacksByCategory",
            //        pattern: "{Controller=Snack}/{action=List}/{snackCategory?}");
            //});

            app.UseMvc(routes =>
            {


                routes.MapRoute("areaRoute", "{area:exists}/{Controller=Admin}/{Action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "filterSnacksByCategory",
                    template: "{Controller=Snack}/{action=List}/{snackCategory?}");
            });

            
        }
    }
}
