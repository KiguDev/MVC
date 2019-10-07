using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.core.Interfaces;
using Restaurante.infrastructure.Data;
using Restaurante.infrastructure.Identity;
using Restaurante.infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Pages;

namespace RestauranteMVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("CatalogConnection")));
            services.AddDbContext<AppIdentityContext>(c => c.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();



            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Cuenta/Login";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            //services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework); 

            //services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultUI();

            services.AddAuthentication().AddFacebook(fbOptions => {
                fbOptions.AppId = "2565621783499841";
                fbOptions.AppSecret = "9e4de8307eef1b008399a2c9e2ad922f";
            });

            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IMesasService, MesasService>();
            services.AddScoped<IEmpleadosService, EmpleadosService>();
            services.AddScoped<IOrdenesService, OrdenesService>();
            services.AddScoped<IAsyncRepository, EfRepository>();
            services.AddScoped<IProductosService, ProductosService>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    //template: "{controller=Cuenta}/{action=Login}");
        });
        }
    }
}
