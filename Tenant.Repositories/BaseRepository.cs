using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tenant.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        internal TenantContext _tenantContext;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(TenantContext tenantContext)
        {
            this._tenantContext = tenantContext;
            this.dbSet = tenantContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            if (_tenantContext.Entry(entityToUpdate).State == EntityState.Detached)
                dbSet.Attach(entityToUpdate);

            _tenantContext.Entry(entityToUpdate).State = EntityState.Modified;
            _tenantContext.SaveChanges();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            _tenantContext.SaveChanges();
        }
     

        public void Delete(TEntity entity)
        {

            dbSet.Remove(entity);
            _tenantContext.SaveChanges();
        }
       
        public void SaveContext()
        {
            _tenantContext.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this._tenantContext != null)
            {
                this._tenantContext.Dispose();
                this._tenantContext = null;
            }
        }
    }
}
