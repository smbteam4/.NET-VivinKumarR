using ROBOT_apocalypse_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApocalypse_BAL.Interface
{
    public interface ISurvivorService
    {
        public  Task<string> CreateSurvivor(CreateSurvivorCommand createSurvivorCommand);
        public  Task<string> UpdateSurvivorLocation(int id, string location);

        public Task<List<Survivors>> GetInfectedSurvivor();
        public Task<List<Survivors>> GetNonInfectedSurvivor();
        public  Task<string> GetInfectedSurvivorPercentage();
        public Task<string> GetNonInfectedSurvivorPercentage();

    }
}
