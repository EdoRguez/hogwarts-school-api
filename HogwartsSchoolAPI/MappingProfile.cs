using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsSchoolAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdmissionApplication, AdmissionApplicationDto>();
            CreateMap<AdmissionApplicationCreateDto, AdmissionApplication>();
            CreateMap<AdmissionApplicationUpdateDto, AdmissionApplication>();

            CreateMap<House, HouseDto>();
        }
    }
}
