 using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.DTOs.CategoryDTOs
{
    public class UpdateCategoryDto:BaseEntityDTOs
    {
        public string Title { get; set; }
        public int? CategoryId { get; set; }
    }
}
