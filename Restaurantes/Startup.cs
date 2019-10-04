using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Services;
using AutoMapper;
using Restaurante.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Restaurantes
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


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI(Microsoft.AspNetCore.Identity.UI.UIFramework.Bootstrap4).AddEntityFrameworkStores<AppIdentityContext>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "1227499694108925";
                facebookOptions.AppSecret = "578773265cc6b867fa079ab7f76f983f";
            });

            //services.AddScoped<IAsyncRepository, EfRepository>();

            /*.AddMicrosoftAccount(microsoftOptions => { }).AddTwitter(twitterOptions => { }).AddGoogle(googleOptions => { });*/

            //services.AddIdentity<IdentityUser, IdentityRole>(options => {
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 5;
                
            //}
            //).AddEntityFrameworkStores<AppIdentityContext>();

            //services.ConfigureApplicationCookie(options => {
            //    options.LoginPath = "/Cuenta/Login";
            //    options.Cookie = new CookieBuilder
            //    {
            //        IsEssential = true
            //    };
            //});

            services.AddScoped<IMesasService, MesasService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IOrdenService, OrdenService>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
            });
        }
    }
}
