namespace UdemyWebApi.DTOs.BaseDTOs
{
    public class BaseAuditableEntityDto:BaseEntityDTOs
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
