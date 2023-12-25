using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.DTOs.CategoryDTOs
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
        public int? CategoryId { get; set; }
    }
}
