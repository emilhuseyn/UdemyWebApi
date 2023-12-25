using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.Entities
{
    public class Student:BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        List<StudentsCourses> StudentsCourses { get; set; }
    }
}
