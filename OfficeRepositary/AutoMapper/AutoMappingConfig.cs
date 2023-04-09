using AutoMapper;
using OfficeModels.Responses;
using Office.DataLayer.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeModels.DTOs;

namespace CollectCoRepositry.AutoMapper
{
    public class AutoMappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, ApplicationUser>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
