using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Models;

namespace UrlHandling.Business.Interfaces.Repository
{
    public interface IRepository<TEntity>: IDisposable where TEntity: Entity
    {
        Task<TEntity> FindById(Guid id);
        Task<IEnumerable<TEntity>> FindAll();
        Task Remove(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
