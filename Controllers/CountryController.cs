using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.DTO.Country;
using Test.Models;
using Test.Repository;
using Test.Repository.IRepository;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ApplicationDbContext dbContext,IMapper mapper,ICountryRepository countryRepository, ILogger<CountryController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var country = await _countryRepository.GetAll();

            var countryDto = _mapper.Map<List<CountryDto>>(country);

           //if (country == null)
           // {
           //     return NoContent();
           // }
            return Ok(countryDto);
        }

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var country = await _countryRepository.Get(id);

            if (country == null)
            {
                _logger.LogError($"Enter the id {id} is invalid");
                return NoContent();
            }

            var countryDto = _mapper.Map<CountryDto>(country);
            
            return Ok(countryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCountryDto>> Create([FromBody] CreateCountryDto countryDto)
        {
            if (countryDto == null)
            {
                
                return BadRequest();
            }
            //Country country = new Country();
            //country.Name = countryDto.Name;
            //country.ShortName = countryDto.ShortName;
            //country.CountryCode = countryDto.CountryCode;

            var country = _mapper.Map<Country>(countryDto);

            await _countryRepository.Create(country);
            return CreatedAtAction("GetById", new {id = country.Id},country);

        }

        [HttpPut]
        public async Task<ActionResult<UpdateCountryDto>> Update([FromBody] UpdateCountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.Update(country);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var country = await _countryRepository.Get(id);
            await _countryRepository.Delete(country);
            return Ok();
        }

    }
}
