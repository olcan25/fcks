using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Business.ViewModel;
using Entity.Concrete;
using Entity.Dto.Company;

namespace Business.Mapping.AutoMapper
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping()
        {
            CreateMap<CompanyModel, Company>();

            CreateMap<Company, GetDtoCompany>();
        }
    }
}
