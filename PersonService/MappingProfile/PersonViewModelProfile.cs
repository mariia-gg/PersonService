using AutoMapper;
using PersonService.BLL.DTO;
using PersonService.Model;

namespace PersonService.MappingProfile
{
    public class PersonViewModelProfile : Profile
    {
        public PersonViewModelProfile()
        {
            CreateMap<PersonDto, PersonCreateViewModel>();
            CreateMap<PersonCreateViewModel, PersonDto>()
                .ForMember(dto => dto.Id, m => m.Ignore());
        }
    }
}
