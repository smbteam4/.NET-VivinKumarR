using RobotApocalypse_BAL.Interface;
using RobotApocalypse_DAL;
using RobotApocalypse_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApocalypse_BAL.Service
{
    public class RobotService: IRobotService
    {
        private readonly ISurvivorRepository _survivorRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IRobotRepository _robotRepository;
        public RobotService(ISurvivorRepository survivorRepository, ApplicationDbContext dbContext,
    IRobotRepository robotRepository
)
        {

            _dbContext = dbContext;
            _survivorRepository = survivorRepository;
            _robotRepository = robotRepository;

        }

        public async Task<List<Robots>> GetRobots()
        {
            var Robots = await _robotRepository.GetAllAsync();
            //  var Robots=_dbContext.Robots.ToList();
            List<Robots> robots = new List<Robots>();
            foreach (var robot in Robots)
            {

                robots.Add(robot);
            }
            return robots;
        }
    }
}
