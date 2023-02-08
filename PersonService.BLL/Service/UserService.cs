using AutoMapper;
using PersonService.BLL.Contract;
using PersonService.BLL.DTO;
using PersonService.Common.Security;
using PesonService.DAL.Contract;
using PesonService.DAL.Entity;

namespace PersonService.BLL.Service;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;

    public UserService(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public bool HasAccessPoint(string userName, AccessPoint accessPoint)
    {
        var user = _repository.GetAll().FirstOrDefault(u => u.UserName == userName);

        if (user == null)
        {
            return false;
        }

        var accessPointId = AccessPointDictionary.GetAccesPointId(accessPoint);

        return user.UserAccessPoints.Any(uap => uap.AccessPointId == accessPointId);
    }

    public async Task<Guid> Create(UserDto user, CancellationToken cancellationToken)
    {
        var entityModel = _mapper.Map<UserEntity>(user);

        await _repository.InsertAsync(entityModel, cancellationToken);

        return entityModel.Id;
    }

    public bool IsValidUser(string userName, string password)
    {
        var isExists = _repository.GetAll().Any(u =>
            u.UserName == userName
            && u.Password == password);

        return isExists;
    }
}