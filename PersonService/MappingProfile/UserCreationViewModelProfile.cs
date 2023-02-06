using AutoMapper;
using PersonService.BLL.DTO;
using PersonService.Model;

namespace PersonService.MappingProfile
{
    public class UserCreationViewModelProfile : Profile
    {
        public UserCreationViewModelProfile()
        {
            CreateMap<UserCreationViewModel, UserDto>();
        }
    }
}
