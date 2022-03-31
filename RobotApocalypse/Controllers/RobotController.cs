using Microsoft.AspNetCore.Mvc;
using RobotApocalypse_BAL;
using RobotApocalypse_BAL.Interface;
using RobotApocalypse_DAL;
using RobotApocalypse_DAL.Interface;

namespace RobotApocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
       
        private readonly IRobotService _robotService;
        

        public RobotController(IRobotService robotService
        )
        {

            _robotService = robotService;
           
         }

        [HttpGet("GetRobots")]
        public async Task<IActionResult> GetRobots()
        {
            return Ok(await _robotService.GetRobots());
        }
    }
}
