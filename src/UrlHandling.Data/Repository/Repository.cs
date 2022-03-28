using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Models;
using UrlHandling.Data.Context;

namespace UrlHandling.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        protected MainUrlHandlingDbContext Db;

        protected DbSet<TEntity> DbSet;

        public IUnitOfWork unitOfWork => Db;

        public Repository(MainUrlHandlingDbContext dbContext)
        {
            this.Db = dbContext;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> FindById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(await this.FindById(id));
            await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
