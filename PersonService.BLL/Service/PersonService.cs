using AutoMapper;
using PersonService.BLL.Contract;
using PersonService.BLL.DTO;
using PesonService.DAL.Contract;
using PesonService.DAL.Entity;

namespace PersonService.BLL.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonEntity> _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepository<PersonEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var persons = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public async Task<Guid> CreateAsync(PersonDto personDto, CancellationToken cancellationToken)
        {
            var personEntity = _mapper.Map<PersonEntity>(personDto);

            personEntity.ModifiedAt = DateTime.UtcNow;
            personEntity.CreatedAt = DateTime.UtcNow;

            await _repository.InsertAsync(personEntity, cancellationToken);

            return personEntity.Id;
        }
    }
}
