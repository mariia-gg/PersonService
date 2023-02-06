using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonService.Attributes;
using PersonService.BLL.Contract;
using PersonService.BLL.DTO;
using PersonService.Common.Security;
using PersonService.Model;

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [RequiredAccessPoints(AccessPoint.PersonController)]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<PersonCreateViewModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PersonCreateViewModel>>(await _personService.GetAllAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<Guid> Create(PersonCreateViewModel personVm, CancellationToken cancellationToken)
        {
            var id = await _personService.CreateAsync(_mapper.Map<PersonDto>(personVm), cancellationToken);

            return id;
        }
    }
}
