using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntityDTOs, new()
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
        Task SaveChangesAsync();

    }
}
