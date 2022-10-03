using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Dtos;
using PlateformService.Models;
using PlateformService.Repositories;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformsController : ControllerBase
    {
        private IPlatformRepository _repository;
        private IMapper _mapper;

        public PlateformsController(IPlatformRepository repository , IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDto>> GetPlatforms()
        {

            Console.WriteLine("-->  Getting Platforms.....");
            var  plateformItem = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlateformReadDto>>(plateformItem));
        }
        [HttpGet("{id}",Name = "GetPlatformById")]

        public ActionResult<PlateformReadDto> GetPlatformById(int id)
        {
            var plateformItem = _repository.GetPlatFormById(id);
            if (plateformItem != null)
            {
                return Ok(_mapper.Map<PlateformReadDto>(plateformItem));


            }
            return NotFound();

            
        }
        [HttpPost]
        public ActionResult<PlateformReadDto> CreatePlatform(PlateformCreateDto plateformCreateDto)
        {
            var plateformModel = _mapper.Map<Plateform>(plateformCreateDto);
            _repository.CreatePlatform(plateformModel);
            _repository.SaveChanges();
            var plateformReadDto = _mapper.Map<PlateformReadDto>(plateformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = plateformReadDto.Id }, plateformReadDto);

        }



    }
}
