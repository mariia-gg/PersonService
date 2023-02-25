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

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var persons = _repository.GetAll();

        return _mapper.Map<IEnumerable<UserDto>>(persons);
    }

    public bool IsValidUser(string userName, string password, string email, int age)
    {
        var isExists = _repository.GetAll().Any(u =>
            u.UserName == userName
            && u.Password == password
            && u.Email == email
            && u.Age == age);

        return isExists;
    }

    public Task<IEnumerable<UserDto>> UpdateUser(CancellationToken cancellationToken) =>
        throw new NotImplementedException();

    public object GetUsers() => throw new NotImplementedException();

    public void UpdateUser(UserDto user)
    {
        throw new NotImplementedException();
    }
} 
    