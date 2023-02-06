using AutoMapper;
using PersonService.BLL.DTO;
using PesonService.DAL.Entity;

namespace PersonService.BLL.MappingProfile
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserDto, UserEntity>(MemberList.Source);
        }
    }
}
