using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.DB.Repositories;
using CKK.DB.UOW;
using CKK.DB.DB;

namespace CKK.Online
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

            services.AddScoped<DatabaseConnectionFactory>();
            services.AddScoped<IProductRepository, ProductRepository>(sp =>
            {
                var factory = sp.GetRequiredService<DatabaseConnectionFactory>();
                return new ProductRepository(factory);
            });
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(sp =>
            {
                var factory = sp.GetRequiredService<DatabaseConnectionFactory>();
                return new ShoppingCartRepository(factory);
            });
            services.AddScoped<IOrderRepository, OrderRepository>(sp =>
            {
                var factory = sp.GetRequiredService<DatabaseConnectionFactory>();
                return new OrderRepository(factory);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>(sp =>
            {
                var factory = sp.GetRequiredService<DatabaseConnectionFactory>();
                return new UnitOfWork(factory);
            });
            //services.AddDbContext<CKKDbContext>(ServiceLifetime.Scoped);

            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();

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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
