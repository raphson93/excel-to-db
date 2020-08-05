using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityDataContext
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected EntityDatabaseContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository(EntityDatabaseContext dbContext)
        {
            DbContext = dbContext ?? throw new NullReferenceException("dbContext");
            DbSet = dbContext.Set<T>();
        }

        #region Implementation of IRepository<T>
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAllInclude(params Expression<Func<T, object>>[] includes)
        {
            return GetResultWithIncludes(includes);
        }

        public IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return GetResultWithIncludes(includes).Where(predicate);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return GetResultWithIncludes(includes).FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            var entry = DbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = DbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }
        #endregion

        private IQueryable<T> GetResultWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            var result = GetAll();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    result = result.Include(include);
                }
            }

            return result;
        }
    }
}
