using AutoMapper;
using Test.DTO.Country;
using Test.DTO.States;
using Test.Models;

namespace Test.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>();
            CreateMap<Country, CountryDto>();


            CreateMap<CreateStatesDto, States>();
            CreateMap<UpdateStatesDto, States>();
            CreateMap<States, StatesDto>();

        } 
    }
}
