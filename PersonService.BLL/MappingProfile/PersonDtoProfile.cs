using AutoMapper;
using PersonService.BLL.DTO;
using PesonService.DAL.Entity;

namespace PersonService.BLL.MappingProfile
{
    public class PersonDtoProfile : Profile
    {
        public PersonDtoProfile()
        {
            CreateMap<PersonEntity, PersonDto>().ReverseMap();
        }
    }
}
