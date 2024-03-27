using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.DTO.States;
using Test.Models;
using Test.Repository;
using Test.Repository.IRepository;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IStatesRepository _statesRepository;

        public StatesController(ApplicationDbContext dbContext, IMapper mapper,IStatesRepository statesRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _statesRepository = statesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatesDto>>> GetAll()
        {
            var states = await _statesRepository.GetAll();

            var statesDto = _mapper.Map<List<StatesDto>>(states);

            //if (country == null)
            // {
            //     return NoContent();
            // }
            return Ok(statesDto);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<StatesDto>> Get(int id)
        {
            var states = await _statesRepository.Get(id);

            var statesDto = _mapper.Map<StatesDto>(states);

            return Ok(statesDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateStatesDto>> Create([FromBody] CreateStatesDto statesDto)
        {
            if (statesDto == null)
            {
                return BadRequest();
            }
            //Country country = new Country();
            //country.Name = countryDto.Name;
            //country.ShortName = countryDto.ShortName;
            //country.CountryCode = countryDto.CountryCode;

            var states = _mapper.Map<States>(statesDto);

            await _statesRepository.Create(states);
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateStatesDto>> Update([FromBody] UpdateStatesDto statesDto)
        {
            var states = _mapper.Map<States>(statesDto);
            await _statesRepository.Update(states);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var states = await _statesRepository.Get(id);
            await _statesRepository.Delete(states);
            return Ok();
        }
    }
 }
