using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Warehouse.Database;

namespace Warehouse
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
            services.AddDbContext<WarehouseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "workers",
                    pattern: "{controller=Warehouse}/{action=Workers}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Warehouse}/{action=Drivers}/{id?}");

                endpoints.MapControllerRoute(
                    name: "storages",
                    pattern: "{controller=Warehouse}/{action=Storages}/{id?}");

                endpoints.MapControllerRoute(
                    name: "orders",
                    pattern: "{controller=Warehouse}/{action=Orders}/{id?}");

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "{controller=Warehouse}/{action=Products}/{id?}");

                endpoints.MapControllerRoute(
                    name: "addProduct",
                    pattern: "{controller=Product}/{action=Add}/{id?}");

                endpoints.MapControllerRoute(
                    name: "deleteProduct",
                    pattern: "{controller=Product}/{action=Delete}/{id?}");

                endpoints.MapControllerRoute(
                    name: "editProduct",
                    pattern: "{controller=Product}/{action=Edit}/{id?}");

                endpoints.MapControllerRoute(
                    name: "infoOrder",
                    pattern: "{controller=Order}/{action=Info}/{id?}");

                endpoints.MapControllerRoute(
                    name: "editOrder",
                    pattern: "{controller=Order}/{action=Edit}/{id?}");

                endpoints.MapControllerRoute(
                    name: "deleteOrder",
                    pattern: "{controller=Order}/{action=Delete}/{id?}");
            });
        }
    }
}
