using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyStore.api;
using VidlyStore.Dtos;
using VidlyStore.Models;

namespace VidlyStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<task, taskDto>();

            
        }
    }
}