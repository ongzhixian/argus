using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Argus.IdentityServer
{
    public class Startup
    {
        public IHostingEnvironment environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            Log.Information("Startup.");

            this.environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information("Configuring services.");

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers());
                ;

            if (this.environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

            // Uncomment to activate MVC framework; needed only if we are using OpenID Connect
            // We do not want to use OpenID Connect by default because we want the idp to be lightweight
            // (and also we do not want to pack the necessary assets (controllers, views, wwwroot, ...etc.) by default)
            // TODO: Setup a `OpenIdConnect` branch to demonstrate this use case.
            // services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);                

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Log.Information("Configuring.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true; 
            }

            app.UseIdentityServer();

            // ZX: Uncomment the below to display a default message
            // DateTime startDate = DateTime.UtcNow; 
            // string runDateMessage = string.Format("Argus -- Started running since {0:O}", startDate);
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync(runDateMessage);
            // });

            // Uncomment to activate MVC framework; needed only if we are using OpenID Connect
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");
            // });
        }
    }
}
