﻿using UdemyWebApi.DTOs.BaseDTOs;

namespace UdemyWebApi.DTOs.CategoryDTOs
{
    public class CategoryGetDto:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
