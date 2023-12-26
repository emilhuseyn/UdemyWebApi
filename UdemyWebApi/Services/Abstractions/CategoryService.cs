using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryIRepository repository, AppDbContext dbContext, IMapper mapper)
        {
            _repository = repository;

            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async void CreateAsync(CategoryCreateDto entity)
        {

            Category category = new Category();
            category.Name = entity.Title;
            Category? category1= _dbContext.Categories.Find(entity.CategoryId);
            if(category1 is not null) category.CategoryId = entity.CategoryId;
            category.IsDeleted = false;
            category.CreatedAt = DateTime.Now;
            
            _repository.CreateAsync(category);

        }

        public void DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
           
                foreach (var item in _dbContext.Categories.Where(c => c.CategoryId == id))
                {
                    item.IsDeleted=true;
                    
                }
            
            _dbContext.SaveChanges();
        }

        public async Task<ICollection<CategoryGetDto>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<CategoryGetDto>>(result.Include(x => x.Children));
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
            Category category = await _dbContext.Categories.FindAsync(entity.Id);

            
            category.Name = entity.Title;
            Category? category1 = _dbContext.Categories.Find(entity.CategoryId);
            if (category1 is not null) category.CategoryId = entity.CategoryId;
            category.IsDeleted = false;
            category.UpdatedAt = DateTime.Now;
            _repository.UpdateAsync(category);
        }
    }
}
