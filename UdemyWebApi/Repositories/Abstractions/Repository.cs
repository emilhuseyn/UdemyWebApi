using Microsoft.EntityFrameworkCore;
using UdemyWebApi.Dal;
using UdemyWebApi.DTOs.BaseDTOs;
using UdemyWebApi.Repositories.Interfaces;

namespace UdemyWebApi.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseEntityDTOs, new()
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
            _table.Remove(entity);
            _dbContext.SaveChanges();

        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> values = _table;
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = _table.Find(id);
            
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
