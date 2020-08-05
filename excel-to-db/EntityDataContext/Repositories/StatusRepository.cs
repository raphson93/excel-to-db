using EntityDataContext.Models;

namespace EntityDataContext.Repositories
{
    public class StatusRepository : Repository<Status>
    {
        public StatusRepository(EntityDatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
