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
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Alan",
                            LastName = "Parson",
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Eddie",
                            LastName = "Murphy",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Elton",
                            LastName = "John",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Freedie",
                            LastName = "Merkury",
                            
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Whitney",
                            LastName = "Houston",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Ariana",
                            LastName = "Grande",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Mariah",
                            LastName = "Carrey",
                           
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Amy",
                            LastName = "Whinehouse",
                            
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Stevie",
                            LastName = "Wonder",
                            
                        }


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
