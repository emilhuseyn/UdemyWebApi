using UdemyWebApi.Dal;
using UdemyWebApi.Entities;
using UdemyWebApi.Repositories.Interfaces;

namespace UdemyWebApi.Repositories.Abstractions
{
    public class CategoryRepository : Repository<Category>, ICategoryIRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
