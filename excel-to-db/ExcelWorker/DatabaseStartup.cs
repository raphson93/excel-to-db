using EntityDataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelWorker
{
    public class DatabaseStartup
    {
        public IConfiguration Configuration { get; }
        public DatabaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Configure Database Context
            services.AddDbContextPool<EntityDatabaseContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("EntityDatabaseConnection")));

            services.AddTransient<EntityDatabase>();
            #endregion
        }
    }
}
