using AutoMapper;
using PersonService.BLL.Contract;
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

        public async Task<bool> IsValidUser(string userName, string password, CancellationToken cancellationToken)
        {
            bool isExists = (await _repository.GetAllAsync(cancellationToken)).Any(u =>
                u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);

            return isExists;
        }
    }
}
