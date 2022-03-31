using RobotApocalypse_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApocalypse_BAL.Interface
{
    public interface IRobotService
    {
        public Task<List<Robots>> GetRobots();
    }
}
