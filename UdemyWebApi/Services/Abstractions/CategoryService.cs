using UdemyWebApi.Dal;
using UdemyWebApi.DTOs.CategoryDTOs;
using UdemyWebApi.Entities;
using UdemyWebApi.Repositories.Interfaces;
using UdemyWebApi.Services.Interfaces;

namespace UdemyWebApi.Services.Abstractions
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryIRepository _repository;
        
        private readonly AppDbContext _dbContext;


        public CategoryService(ICategoryIRepository repository, AppDbContext dbContext)
        {
            _repository = repository;
            
            _dbContext = dbContext;
        }

        public async void CreateAsync(CategoryCreateDto entity)
        {

            Category category = new Category();
            category.Name = entity.Title;
            if(entity.CategoryId is not null)category.CategoryId = entity.CategoryId;
            category.IsDeleted = false;
            category.CreatedAt = DateTime.Now;
            
            _repository.CreateAsync(category);

        }

        public void DeleteAsync(int id)
        {
            
            _repository.DeleteAsync(id);
        }

        public async Task<IQueryable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            
            return await _repository.GetByIdAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return _repository.SaveChangesAsync();
        }

        public async void UpdateAsync(UpdateCategoryDto entity )
        {
            Category category = await _repository.GetByIdAsync(entity.Id);
            category.Name = entity.Title;
            if(entity.CategoryId is not null) category.CategoryId = entity.CategoryId;
            category.UpdatedAt = DateTime.Now;
            _repository.UpdateAsync(category);
        }
    }
}
