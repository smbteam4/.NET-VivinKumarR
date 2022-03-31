using ROBOT_apocalypse_DAL.Model;
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
    public class SurvivorService : ISurvivorService
    {
        private readonly ISurvivorRepository _survivorRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IRobotRepository _robotRepository;
        public SurvivorService(ISurvivorRepository survivorRepository, ApplicationDbContext dbContext,
    IRobotRepository robotRepository
)
        {

            _dbContext = dbContext;
            _survivorRepository = survivorRepository;
            _robotRepository = robotRepository;

        }

        public async Task<string> CreateSurvivor(CreateSurvivorCommand createSurvivorCommand)
        {
            var isSurvivorInfected = "";
            var survivor = await _survivorRepository.GetAllAsync();
            if (survivor.Count >= 3)
            {
                isSurvivorInfected = "Infected";
            }
            else
            {
                isSurvivorInfected = "NotInfect";
            }
            Survivors survivors = new Survivors();
            survivors.Name = createSurvivorCommand.Name;
            survivors.LastLocation = createSurvivorCommand.LastLocation;
            survivors.Gender = createSurvivorCommand.Gender;
            survivors.Age = createSurvivorCommand.Age;
            survivors.Resources = createSurvivorCommand.Resources;
            survivors.Status = isSurvivorInfected;
            await _survivorRepository.AddAsync(survivors);

            return "Survivor created ";
        }

        public async Task<List<Survivors>> GetInfectedSurvivor()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var infectedSurvivor = survivors.Where(o => o.Status == "Infected").ToList();

            return infectedSurvivor;
        }

        public async Task<string> GetInfectedSurvivorPercentage()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var infectedSurvivor = survivors.Where(o => o.Status == "Infected").ToList();
            var infectedSurvivorPercentage = ((double)infectedSurvivor.Count / survivors.Count) * 100;

            return infectedSurvivorPercentage + "%";
        }

        public async Task<List<Survivors>> GetNonInfectedSurvivor()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var nonInfectedSurvivor = survivors.Where(o => o.Status == "notinfect").ToList();

            return nonInfectedSurvivor;
        }

        public async Task<string> GetNonInfectedSurvivorPercentage()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var nonInfectedSurvivor = survivors.Where(o => o.Status == "notinfect").ToList();
            var nonInfectedSurvivorPercentage = ((double)nonInfectedSurvivor.Count / survivors.Count) * 100;

            return nonInfectedSurvivorPercentage + "%";
        }

        public async Task<string> UpdateSurvivorLocation(int id, string location)
        {
            var survivors = await _survivorRepository.GetByIdAsync(id);
            survivors.LastLocation = location;
            await _survivorRepository.UpdateAsync(survivors);
            return "Location updated succesfully";
        }
    }
}