/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace EventQuery.Service
{
    using Engaze.Core.Persistance.Cassandra;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using EventQuery.DataPersistance;
    using Serilog;
    using Engaze.Core.Web;

    public class Startup : EngazeStartup
    {
        public Startup(IConfiguration configuration) : base(configuration) { }   

        public override void ConfigureComponentServices(IServiceCollection services)
        {
            services.ConfigureCloudCassandra(Configuration);
            services.AddTransient<IEventManager, EventManager>();
            services.AddTransient<IEventRepository, EventRepository>();
        }

        public override void ConfigureComponent(IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
        }
    }
}
