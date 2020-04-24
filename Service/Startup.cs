/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace EventQuery.Service
{
    using Engaze.Core.Persistance.Cassandra;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using EventQuery.DataPersistance;
    using Serilog;

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
            services.AddControllers();
            services.ConfigureCassandraServices(Configuration);                     
            services.AddTransient<IEventManager,EventManager>();
            services.AddTransient<IEventRepository, EventRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAppException();

            app.UseAppStatus();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Use)
        }
    }
}
