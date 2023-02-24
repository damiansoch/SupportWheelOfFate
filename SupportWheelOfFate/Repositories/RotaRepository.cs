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


        public async Task<IEnumerable<Shift>> CreateSchedule()
        {
            var allEngineers = await context.Engineers.ToListAsync();

            //creating list of engineers for morning shift
            var allMorningEnginiers = allEngineers.ToList();

            List<Engineer> randomMorningEngineers = new();

            Random rnd = new();


            #region creating random list of morning shifts
            while (allMorningEnginiers.Count > 0)
            {
                var randomIndex = rnd.Next(0, allMorningEnginiers.Count);
                var randomEngineer = allMorningEnginiers[randomIndex];
                randomMorningEngineers.Add(randomEngineer);
                allMorningEnginiers.Remove(randomEngineer);
            }
            #endregion

            #region creating random list of afternoon shifts
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
            #endregion


            #region  checking for the given rules, if not good random the afternoon again
            //if rules no longer apply this function callback can be removed together wit the function at the bottom
            randomAfternoonEngineers= CheckForRules(
                allEngineers, 
                allAfternoonEnginiers, 
                randomAfternoonEngineers, 
                randomMorningEngineers);
            #endregion

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

        //------------------------------------------------
        #region method that checks for the rules given
        public List<Engineer> CheckForRules(List<Engineer> allEngineers,List<Engineer> allAfternoonEnginiers,List<Engineer> randomAfternoonEngineers, List<Engineer> randomMorningEngineers)
        {
            Random rnd = new();
            var countR = 0;
            while (countR < allEngineers.Count)
            {
                //setting up the variables to check the rules
                var countRMinus = countR - 1;
                if (countR == 0)
                {
                    countRMinus = allEngineers.Count;
                }
                var countRPlus = countR + 1;
                if (countR == allEngineers.Count)
                {
                    countRPlus = 0;
                }


                //checking for the firs morning engineer
                if (countR == 0)
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
                else if (countR == allEngineers.Count - 1)
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
            return randomAfternoonEngineers;
        }
        #endregion

    }



}

