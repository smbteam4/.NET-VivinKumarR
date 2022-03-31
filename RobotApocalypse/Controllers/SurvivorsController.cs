using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ROBOT_apocalypse_DAL.Model;
using RobotApocalypse_BAL;
using RobotApocalypse_BAL.Interface;
using RobotApocalypse_DAL;
using RobotApocalypse_DAL.Interface;

namespace RobotApocalyps.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class SurvivorsController : Controller
        {
        public readonly ISurvivorService _survivorService;
        public SurvivorsController(ISurvivorService survivorService)
        {
            _survivorService = survivorService;
        }
        // GET: api/<controller>
        [HttpPost]
            public async Task<IActionResult> CreateSurvivor(CreateSurvivorCommand createSurvivorCommand )
            {
            return Ok(await _survivorService.CreateSurvivor(createSurvivorCommand));
            }
        [HttpPut]
        public async Task<IActionResult> UpdateSurvivorLocation(int id, string location)
        {

            return Ok(await _survivorService.UpdateSurvivorLocation(id, location));
        }

        [HttpGet("ListOfInfectedSurvivor")]
        public async Task<IActionResult> GetInfectedSurvivor()
        {
            return Ok(await _survivorService.GetInfectedSurvivor());

        }
        [HttpGet("ListOfNonInfectedSurvivor")]
        public async Task<IActionResult> GetNonInfectedSurvivor()
        {
            return Ok(await _survivorService.GetNonInfectedSurvivor());

        }
        [HttpGet("PercentageOfInfectedSurvivor")]
        public async Task<IActionResult> GetInfectedSurvivorPercentage()
        {
            return Ok(await _survivorService.GetInfectedSurvivorPercentage());

        }
        [HttpGet("PercentageOfNonInfectedSurvivor")]
        public async Task<IActionResult> GetNonInfectedSurvivorPercentage()
        {
            return Ok(await _survivorService.GetNonInfectedSurvivorPercentage());

        }
    }
    }
