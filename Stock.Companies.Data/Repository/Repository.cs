using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Companies.Data.Context;
using Stock.Companies.Domain.Entities;
using Stock.Companies.Domain.Interfaces;

namespace Stock.Companies.Data.Repository
{
    /// <summary>
    /// Generic Repository for any Entity that inherit from Entity with common methods
    /// The methods can also be overridden
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MSSQLContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(MSSQLContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> GetById(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid Id)
        {
            _dbSet.Remove(new TEntity{Id = Id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}