using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Repositories
{
    public interface IBaseRepository<TEntity> 
    {
        void Dispose();
        IQueryable<TEntity> GetAll();
        void Update(TEntity entityToUpdate);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void SaveContext();
    }
}
