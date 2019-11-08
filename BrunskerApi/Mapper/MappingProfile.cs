using AutoMapper;
using BrunskerApi.DTO;
using BrunskerApi.Models;

namespace BrunskerApi.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserForRegister>().ReverseMap();                      
            CreateMap<User,UserForList>().ReverseMap();                      
        }
    }
}