using AutoMapper;
using ComandsService.Data;
using ComandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ComandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("---> Get Platforms from CommandsService");
            var platformsItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsItems));
        }

        [HttpPost]
        public ActionResult TestInboundConnect()
        {
            Console.WriteLine("---> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controller");
        }
    }
}