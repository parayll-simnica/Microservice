using Microsoft.AspNetCore.Mvc;

namespace ComandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController() { }

        [HttpPost]
        public ActionResult TestInboundConnect()
        {
            Console.WriteLine("---> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controller");
        }
    }
}