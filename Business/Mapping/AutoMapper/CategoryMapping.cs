using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Category;

namespace Business.Mapping.AutoMapper
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, GetDtoCategory>();

            CreateMap<DtoCategory, Category>();
        }
    }
}
