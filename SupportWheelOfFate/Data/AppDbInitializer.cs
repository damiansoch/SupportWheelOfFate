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
                            FirstName = "Engineer",
                            LastName = "One",
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Two",
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Three",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Four",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Five",
                            
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Six",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Seven",
                           
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Eight",
                           
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Nine",
                            
                            
                        },
                         new Engineer()
                        {
                            Id = new Guid(),
                            FirstName = "Engineer",
                            LastName = "Ten",
                            
                        }


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
