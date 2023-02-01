using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonService.BLL.Contract;
using PersonService.BLL.DTO;
using PersonService.Model;

namespace PersonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //[HttpGet("{id}")]
        //public IActionResult Get(Guid id)
        //{
        //    return Ok(null);
        //}
    }
}
