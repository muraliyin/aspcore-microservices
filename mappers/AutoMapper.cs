using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using aspcorewebapis.Entities;
using aspcorewebapis.dtos;
using aspcorewebapis.Models;
namespace aspcorewebapis.mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Companies, CompanyViewDto>();
            CreateMap<CompanyViewDto, Companies>(); 
            CreateMap<CompanyInputDto, Companies>();
            CreateMap<CompanyInputUpdateDto, Companies>();
            
        }

    }
}
