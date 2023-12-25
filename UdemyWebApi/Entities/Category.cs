using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.Entities
{
    public class Category:BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        
        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category>? Children { get; set; }

    }
}
