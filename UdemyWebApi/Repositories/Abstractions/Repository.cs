using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using UdemyWebApi.Dal;
using UdemyWebApi.DTOs.BaseDTOs;
using UdemyWebApi.Repositories.Interfaces;

namespace UdemyWebApi.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntityDto, new()
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public void CreateAsync(T entity)
        {
            _table.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
            T entity = _table.Find(id);
            entity.IsDeleted = true;
             _dbContext.SaveChanges();

            

        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = _table.Where(i=>i.IsDeleted==false);
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query.Include(includes[i]);
                }
            }

            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = _table.Where(i=>i.IsDeleted==false).FirstOrDefault(i=>i.Id==id);
            
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async void UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
