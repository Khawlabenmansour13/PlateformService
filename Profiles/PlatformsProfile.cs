using AutoMapper;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlatformsProfile : Profile
    {
       public PlatformsProfile() 
        {
            CreateMap<Plateform, PlateformReadDto>();
            CreateMap<PlateformCreateDto, Plateform>();
        }
    }
}
