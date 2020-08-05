using EntityDataContext.Models;

namespace EntityDataContext.Repositories
{
    public class ReportRepository : Repository<Report>
    {
        public ReportRepository(EntityDatabaseContext dbContext) : base(dbContext){}
    }
}
