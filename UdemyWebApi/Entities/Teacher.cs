using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.Entities
{
    public class Teacher:BaseAuditableEntityDto
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
    }
}
