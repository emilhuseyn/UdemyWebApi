using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.Entities
{
    public class Course:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public List<StudentsCourses> StudentsCourses { get; set; }
    }
}
