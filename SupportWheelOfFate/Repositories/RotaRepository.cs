using Microsoft.EntityFrameworkCore;
using SupportWheelOfFate.Data;
using SupportWheelOfFate.Models;
using System.Collections.Generic;

namespace SupportWheelOfFate.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly AppDbContext context;

        public RotaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shift>> CreateRota()
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

            while (counter < randomlySelectedEngineersMorning.Count)
            {
                
                var index = counter + 2;
                if (index == randomlySelectedEngineersMorning.Count)
                {
                    index = 0;
                }
                else if (index == randomlySelectedEngineersMorning.Count + 1)
                {
                    index = 1;
                }
                var engineer = randomlySelectedEngineersMorning[index];
                randomlySelectedEngineersAfternoon.Add(engineer);

                counter++;

            }


            List<Shift> allShiftsCovered = new List<Shift>();

            for (int i = 0; i < randomlySelectedEngineersMorning.Count; i++)
            {
                Shift shiftMorning = new Shift()
                {
                    Id=Guid.NewGuid(),
                    Day=i+1,
                    TimeOfDay="Morning",
                    Engineer= randomlySelectedEngineersMorning[i],
                };
                

                Shift shiftAfternoon = new Shift()
                {
                    Id = Guid.NewGuid(),
                    Day = i + 1,
                    TimeOfDay = "Afternoon",
                    Engineer = randomlySelectedEngineersAfternoon[i],
                };
                allShiftsCovered.Add(shiftMorning);
                allShiftsCovered.Add(shiftAfternoon);

            }

            return allShiftsCovered;
        }



        //--------------------------------------------------------------------------------------------



        //public async Task<IEnumerable<Shift>> CreateRotaFullRandom()
        //{
        //    var allEngineers = await context.Engineers.ToListAsync();
        //    var allEngineersMorning = allEngineers.ToList();

        //    //creating random list form morning shifts
        //    List<Engineer> randomlySelectedEngineersMorning = new List<Engineer>();

        //    while (allEngineersMorning.Count > 0)
        //    {
        //        Random rnd = new Random();
        //        var engineer = allEngineersMorning[rnd.Next(0, allEngineersMorning.Count - 1)];

        //        randomlySelectedEngineersMorning.Add(engineer);
        //        allEngineersMorning.Remove(engineer);
        //    }
        //    //creating random list for afternoon shifts

        //    List<Engineer> randomlySelectedEngineersAfternoon = new List<Engineer>();



        //    for (int i = 0; i < randomlySelectedEngineersMorning.Count; i++)
        //    {
        //        Random rnd = new Random();

        //        var index = rnd.Next(i + 2, i + randomlySelectedEngineersMorning.Count - 1 - 1);
        //        //count -1 besause of the index starts form 0
        //        if (index > randomlySelectedEngineersMorning.Count - 1)
        //        {
        //            index = index - randomlySelectedEngineersMorning.Count;
        //        }
        //        var engineer = randomlySelectedEngineersMorning[index];

        //        while ( engineer.Selected==true)
        //        {
        //             index = rnd.Next(i + 2, i + randomlySelectedEngineersMorning.Count - 1 - 1);
        //            //count -1 besause of the index starts form 0
        //            if (index > randomlySelectedEngineersMorning.Count - 1)
        //            {
        //                index = index - randomlySelectedEngineersMorning.Count;
        //            }

        //            engineer = randomlySelectedEngineersMorning[index];
        //        }
        //        engineer.Selected = true;
        //        randomlySelectedEngineersAfternoon.Add(engineer);
        //    }


        //    List<Shift> allShiftsCovered = new List<Shift>();

        //    for (int i = 0; i < randomlySelectedEngineersMorning.Count; i++)
        //    {
        //        Shift newShiftMorning = new Shift()
        //        {
        //            Id = Guid.NewGuid(),
        //            Day = i,
        //            TimeOfDay = "Morning",
        //            Engineer = randomlySelectedEngineersMorning[i],
        //        };
        //        allShiftsCovered.Add(newShiftMorning);

        //        Shift newShiftAfternoon = new Shift()
        //        {
        //            Id = Guid.NewGuid(),
        //            Day = i,
        //            TimeOfDay = "Afternoon",
        //            Engineer = randomlySelectedEngineersAfternoon[i],
        //        };
        //        allShiftsCovered.Add(newShiftAfternoon);
        //    }

        //    return allShiftsCovered;
        //}
    }







}
