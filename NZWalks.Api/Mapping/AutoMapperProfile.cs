using AutoMapper;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Region,CreateRegionDto>().ReverseMap();
            CreateMap<Region,UpdateRegionDto>().ReverseMap();
        }
    }
}
