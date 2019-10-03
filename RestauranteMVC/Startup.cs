using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using Restaurante.Infrastructure.Identity;
using Restaurante.Infrastructure.Interfaces;
using Restaurante.Infrastructure.Services;
using System;

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

            services.ConfigureApplicationCookie(opts => {
                opts.LoginPath = "/Cuenta/Login";
                opts.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });
            services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppSecret = "";
                facebookOptions.AppId = "";
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IRestauranteService,RestauranteService>();
            services.AddScoped<IMesasService, MesaService>();// Crea una instancia cada vez que se hacen un peticion
            services.AddScoped<IOrdenService, OrdenService>();
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
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
