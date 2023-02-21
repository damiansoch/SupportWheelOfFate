using Microsoft.EntityFrameworkCore;
using SupportWheelOfFate.Data;
using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly AppDbContext context;

        public RotaRepository(AppDbContext context )
        {
            this.context = context;
        }

        public async Task<IEnumerable<Engineer>> CreateRota()
        {
            var allEngineers = await context.Engineers.ToListAsync();

           


            //creating random list of 20
            List<Engineer> randomlySelectedEngineers= new List<Engineer>();

            for (int i = 0; i < allEngineers.Count * 2; i++)
            {
                Random rnd = new Random();
                var engineer = allEngineers[rnd.Next(0, allEngineers.Count - 1)];
                if (randomlySelectedEngineers.Count < 2)
                {
                    randomlySelectedEngineers.Add(engineer);
                }
                else
                {
                    while (engineer.Id == randomlySelectedEngineers[i - 1].Id || engineer.Id == randomlySelectedEngineers[i - 2].Id)
                    {
                        engineer = allEngineers[rnd.Next(0, allEngineers.Count - 1)];
                    }
                    randomlySelectedEngineers.Add(engineer);
                }
               
                
            }



            return randomlySelectedEngineers;
           
        }
    }
    

   

  


}
