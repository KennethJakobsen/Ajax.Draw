using System;
using System.IO;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Acme.Draw.Core.IoC;
using LightInject.Microsoft.DependencyInjection;
using LinqToDB.Data;

namespace Acme_Draw
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            var bootstrapper = new Bootstrapper();
            bootstrapper.RegisterServices();
            DataConnection.DefaultSettings = new OrmSettings(CreateSettings());

            return bootstrapper.Container.CreateServiceProvider(services);
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ProductRegistration}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "ProductRegistration", action = "Index" });
            });
        }

        private AcmeSettings CreateSettings()
        {

            return new AcmeSettings(Configuration[$"{nameof(AcmeSettings)}:{nameof(AcmeSettings.SqlConnectionString)}"]);
            
        }
    }
}
