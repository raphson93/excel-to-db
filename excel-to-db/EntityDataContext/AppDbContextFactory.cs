using Microsoft.EntityFrameworkCore;

namespace EntityDataContext
{
    public class AppDbContextFactory : DesignTimeDbContextFactory<EntityDatabaseContext>
    {
        protected override EntityDatabaseContext CreateNewInstance(DbContextOptions<EntityDatabaseContext> options)
        {
            return new EntityDatabaseContext(options);
        }
    }
}
