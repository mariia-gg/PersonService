namespace PersonService.BLL.Contract
{
    public interface IUserService
    {
        Task<bool> IsValidUser(string userName, string password, CancellationToken cancellationToken);
    }
}