using Microsoft.EntityFrameworkCore;
using SupportWheelOfFate.Data;
using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly AppDbContext context;

        public RotaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Engineer>> CreateRota()
        {
            var allEngineers = await context.Engineers.ToListAsync();
            var allEngineersMorning = allEngineers.ToList();
            var allEngineersAfternoon = allEngineers.ToList();




            //creating random list form morning shifts
            List<Engineer> randomlySelectedEngineersMorning = new List<Engineer>();

            while (allEngineersMorning.Count > 0)
            {
                Random rnd = new Random();
                var engineer = allEngineersMorning[rnd.Next(0, allEngineersMorning.Count - 1)];

                randomlySelectedEngineersMorning.Add(engineer);
                allEngineersMorning.Remove(engineer);
            }
            //creating random list for afternoon shifts

            List<Engineer> randomlySelectedEngineersAfternoon = new List<Engineer>();
            

            var counter = 0;

            while (counter<randomlySelectedEngineersMorning.Count)
            {
                Random rnd = new Random();
                var index = counter + 2;
                if(index == randomlySelectedEngineersMorning.Count) 
                {
                    index = 0;
                }else if(index== randomlySelectedEngineersMorning.Count + 1)
                {
                    index= 1;
                }
                var engineer = randomlySelectedEngineersMorning[index];
                randomlySelectedEngineersAfternoon.Add(engineer);

                counter++;
               
            }


            List<Engineer> allShiftsCovered = new List<Engineer>();

            for (int i = 0; i < randomlySelectedEngineersMorning.Count; i++)
            {
                allShiftsCovered.Add(randomlySelectedEngineersMorning[i]);
                allShiftsCovered.Add(randomlySelectedEngineersAfternoon[i]);
            }

            return allShiftsCovered;
        }


    }







}
