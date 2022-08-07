using CarParkUser.Resources;
using CoreLayer.Repository.Abstract;
using CoreLayer.Settings;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarParkUser
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
            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(opts =>
                {
                    opts.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assamblyName = new AssemblyName(typeof(SharedModelsResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create(nameof(SharedModelsResource), assamblyName.Name);
                    };
                });
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionStrings = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));

            services.AddLocalization();

            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                    new CultureInfo("ar-SA")
                };
                opts.DefaultRequestCulture = new RequestCulture("tr-TR");
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;

                //opts.RequestCultureProviders = new List<IRequestCultureProvider>
                //{
                //    new QueryStringRequestCultureProvider(),
                //    new CookieRequestCultureProvider(),
                //    new AcceptLanguageHeaderRequestCultureProvider(),
                //};

                opts.RequestCultureProviders = new[] {new RouteDataRequestCultureProvider()
                {
                    Options = opts 
                } };

            });

            services.AddControllersWithViews();
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
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
