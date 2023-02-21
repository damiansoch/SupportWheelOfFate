using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if(!context.Engineers.Any())
                {
                    context.Engineers.AddRange(new List<Engineer>(){
                        new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "John",
                            LastName = "Travolta",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Alan",
                            LastName = "Parson",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Eddie",
                            LastName = "Murphy",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Elton",
                            LastName = "John",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Freedie",
                            LastName = "Merkury",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Whitney",
                            LastName = "Houston",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Ariana",
                            LastName = "Grande",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Mariah",
                            LastName = "Carrey",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Amy",
                            LastName = "Whinehouse",
                            FristShift = false,
                            SecondShift = false,
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Stevie",
                            LastName = "Wonder",
                            FristShift = false,
                            SecondShift = false,
                        }


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
