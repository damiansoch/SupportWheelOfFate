using Microsoft.EntityFrameworkCore;
using SupportWheelOfFate.Data;
using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly AppDbContext context;

        public EngineerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Engineer>> GetAllAsync()
        {
            return await context.Engineers.ToListAsync();
        }
    }
}
