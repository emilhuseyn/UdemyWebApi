using UdemyWebApi.DTOs.CategoryDTOs;
using UdemyWebApi.Entities;

namespace UdemyWebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        void CreateAsync(CategoryCreateDto entity );
        void UpdateAsync(UpdateCategoryDto entity);
        void DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
