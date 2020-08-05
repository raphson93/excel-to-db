using EntityDataContext.Repositories;
using System;
using System.Threading.Tasks;

namespace EntityDataContext
{
    public class EntityDatabase
    {
        private readonly EntityDatabaseContext _entityDatabaseContext;

        public EntityDatabase(EntityDatabaseContext entityDatabaseContext)
        {
            _entityDatabaseContext = entityDatabaseContext;
        }

        public void Save()
        {
            _entityDatabaseContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _entityDatabaseContext.SaveChangesAsync();
        }

        public ReportRepository Reports => new ReportRepository(_entityDatabaseContext);
        public StatusRepository Statuses => new StatusRepository(_entityDatabaseContext);

    }
}
