using System.Linq.Expressions;
using UdemyWebApi.DTOs.CategoryDTOs;
using UdemyWebApi.Entities;

namespace UdemyWebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryGetDto>> GetAllAsync(Expression<Func<Category, bool>>? expression = null,Expression<Func<Category, object>>? expressionOrder = null,bool isDescending = false,params string[] includes); 
        Task<Category> GetByIdAsync(int id);
        void CreateAsync(CategoryCreateDto entity );
        void UpdateAsync(UpdateCategoryDto entity);
        void DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
