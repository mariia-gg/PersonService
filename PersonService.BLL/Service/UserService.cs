using PersonService.BLL.Contract;
using PersonService.Common.Security;
using PesonService.DAL.Contract;
using PesonService.DAL.Entity;

namespace PersonService.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public bool IsValidUser(string userName, string password)
        {
            bool isExists = _repository.GetAll().Any(u =>
                u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);

            return isExists;
        }

        public bool HasAccessPoint(string userName, AccessPoint accessPoint)
        {
            var user = _repository.GetAll().FirstOrDefault(u => u.UserName == userName);

            if (user == null) return false;

            var accessPointId = AccessPointDictionary.GetAccesPointId(accessPoint);

            return user.UserAccessPoints.Any(uap => uap.AccessPointId == accessPointId);
        }
    }
}
