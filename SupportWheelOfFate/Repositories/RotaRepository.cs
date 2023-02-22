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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<IEnumerable<Shift>> CreateSchedule()
        {
            var allEngineers = await context.Engineers.ToListAsync();

            //creating list of engineers for morning shift
            var allMorningEnginiers = allEngineers.ToList();

            List<Engineer> randomMorningEngineers = new();

            Random rnd = new();

            while (allMorningEnginiers.Count > 0)
            {
                var randomIndex = rnd.Next(0, allMorningEnginiers.Count);
                var randomEngineer = allMorningEnginiers[randomIndex];
                randomMorningEngineers.Add(randomEngineer);
                allMorningEnginiers.Remove(randomEngineer);
            }

            //creating list of engineers for afternoon shift
            var allAfternoonEnginiers = allEngineers.ToList();
            List<Engineer> randomAfternoonEngineers = new();

            while (allAfternoonEnginiers.Count > 0)
            {
                var randomIndex = rnd.Next(0, allMorningEnginiers.Count);
                var randomEngineer = allAfternoonEnginiers[randomIndex];
                randomAfternoonEngineers.Add(randomEngineer);
                allAfternoonEnginiers.Remove(randomEngineer);
            }

            //checking for the given rules, if not good random the afternoon again
            var countR = 0;
            while (countR<allEngineers.Count)
            {
                //setting up the variables to check the rules
                var countRMinus = countR - 1;
                if (countR==0)
                {
                    countRMinus = allEngineers.Count;
                }
                var countRPlus = countR + 1;
                if (countR == allEngineers.Count)
                {
                    countRPlus = 0;
                }

                
                //checkin for the firs morning engineer
                if (countR==0)
                {
                    if (randomMorningEngineers[countR].Id == randomAfternoonEngineers[countR].Id ||
                   randomMorningEngineers[countR].Id == randomAfternoonEngineers[countRPlus].Id)
                    {
                        //clearing the list
                        randomAfternoonEngineers.Clear();
                        //creating list of engineers for afternoon shift
                        allAfternoonEnginiers = allEngineers.ToList();

                        while (allAfternoonEnginiers.Count > 0)
                        {

                            var randomIndex = rnd.Next(0, allAfternoonEnginiers.Count);
                            var randomEngineer = allAfternoonEnginiers[randomIndex];
                            randomAfternoonEngineers.Add(randomEngineer);
                            allAfternoonEnginiers.Remove(randomEngineer);
                        }
                        countR = -1;
                    }
                    countR++;
                }
                //checking for the last morning engineer
                else if (countR==allEngineers.Count-1)
                {
                    if (randomMorningEngineers[countR].Id == randomAfternoonEngineers[countR].Id ||
                   randomMorningEngineers[countR].Id == randomAfternoonEngineers[countRMinus].Id)
                    {
                        //clearing the list
                        randomAfternoonEngineers.Clear();
                        //creating list of engineers for afternoon shift
                        allAfternoonEnginiers = allEngineers.ToList();

                        while (allAfternoonEnginiers.Count > 0)
                        {

                            var randomIndex = rnd.Next(0, allAfternoonEnginiers.Count);
                            var randomEngineer = allAfternoonEnginiers[randomIndex];
                            randomAfternoonEngineers.Add(randomEngineer);
                            allAfternoonEnginiers.Remove(randomEngineer);
                        }
                        countR = -1;
                    }
                    countR++;
                }
                //checking for everything else
                else
                {
                    if (randomMorningEngineers[countR].Id == randomAfternoonEngineers[countR].Id ||
                                       randomMorningEngineers[countR].Id == randomAfternoonEngineers[countRMinus].Id ||
                                       randomMorningEngineers[countR].Id == randomAfternoonEngineers[countRPlus].Id)
                    {
                        //clearing the list
                        randomAfternoonEngineers.Clear();
                        //creating list of engineers for afternoon shift
                        allAfternoonEnginiers = allEngineers.ToList();

                        while (allAfternoonEnginiers.Count > 0)
                        {

                            var randomIndex = rnd.Next(0, allAfternoonEnginiers.Count);
                            var randomEngineer = allAfternoonEnginiers[randomIndex];
                            randomAfternoonEngineers.Add(randomEngineer);
                            allAfternoonEnginiers.Remove(randomEngineer);
                        }
                        countR = -1;
                    }
                    countR++;
                }

                
            }

            //creating shifts for the 10 days
            List<Shift> allShifts = new();

            for (int i = 0; i < allEngineers.Count; i++)
            {
                Shift newMorningShift = new()
                {
                    Id = Guid.NewGuid(),
                    Day = i + 1,
                    TimeOfDay = "Morning",
                    Engineer = randomMorningEngineers[i],
                };
                Shift newAfternoonShift = new()
                {
                    Id = Guid.NewGuid(),
                    Day = i + 1,
                    TimeOfDay = "Afternoon",
                    Engineer = randomAfternoonEngineers[i],
                };
                allShifts.Add(newMorningShift);
                allShifts.Add(newAfternoonShift);
            }
            return allShifts;
        }

        /// <summary>
        /// This one the afternoon not really random, based on the morning that is ully random
        /// </summary>
        /// <returns></returns>

        //public async Task<IEnumerable<Shift>> CreateRota()
        //{
        //    var allEngineers = await context.Engineers.ToListAsync();
        //    //extra list just so i can remove the engineers selected before
        //    var allEngineersMorning = allEngineers.ToList();





        //    //creating random list form morning shifts
        //    List<Engineer> randomlySelectedEngineersMorning = new();

        //    while (allEngineersMorning.Count > 0)
        //    {
        //        Random rnd = new();
        //        var engineer = allEngineersMorning[rnd.Next(0, allEngineersMorning.Count - 1)];

        //        //adding the engineer to the morning shift list
        //        randomlySelectedEngineersMorning.Add(engineer);
        //        //deleting selected engineer from the list
        //        allEngineersMorning.Remove(engineer);
        //    }

        //    //creating afternoon shifts
        //    List<Engineer> randomlySelectedEngineersAfternoon = new();


        //    var counter = 0;

        //    while (counter < randomlySelectedEngineersMorning.Count)
        //    {

        //        //not the same day and not next day
        //        var index = counter + 2;
        //        if (index == randomlySelectedEngineersMorning.Count)
        //        {
        //            index = 0;
        //        }
        //        else if (index == randomlySelectedEngineersMorning.Count + 1)
        //        {
        //            index = 1;
        //        }
        //        var engineer = randomlySelectedEngineersMorning[index];
        //        //adding the engineer to the afternoon shift list
        //        randomlySelectedEngineersAfternoon.Add(engineer);

        //        counter++;

        //    }


        //    //creating the shifts
        //    List<Shift> allShiftsCovered = new();

        //    for (int i = 0; i < randomlySelectedEngineersMorning.Count; i++)
        //    {
        //        Shift shiftMorning = new Shift()
        //        {
        //            Id=Guid.NewGuid(),
        //            Day=i+1,
        //            TimeOfDay="Morning",
        //            Engineer= randomlySelectedEngineersMorning[i],
        //        };


        //        Shift shiftAfternoon = new Shift()
        //        {
        //            Id = Guid.NewGuid(),
        //            Day = i + 1,
        //            TimeOfDay = "Afternoon",
        //            Engineer = randomlySelectedEngineersAfternoon[i],
        //        };
        //        allShiftsCovered.Add(shiftMorning);
        //        allShiftsCovered.Add(shiftAfternoon);

        //    }

        //    return allShiftsCovered;
        //}

        /// <summary>
        ///I tried to do the afternoon shift fully random as well, but it always ended up with some errors at the end... 
        ///the reason is that the last picks for the afternoon shifts the same day or consecutive day
        /// </summary>

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

