using PersonService.BLL.DTO;

namespace PersonService.BLL.Contract
{
    public interface IPersonService
    {
        Task<Guid> CreateAsync(PersonDto personDto, CancellationToken cancellationToken);
        Task<IEnumerable<PersonDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}